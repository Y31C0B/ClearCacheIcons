using System;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace ClearCacheIcons
{
    public static class IconCacheCleaner
    {
        public static bool IsAdministrator()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

        public static void ClearIconCache()
        {
            Logger.Log(LocalizationManager.GetString("Log_CheckingAdminRights"));

            if (!IsAdministrator())
            {
                Logger.Log(LocalizationManager.GetString("Log_AdminRequired"), true);

                using (var form = new CustomMessageBoxForm(
                    LocalizationManager.GetString("Log_AdminRequired"),
                    LocalizationManager.GetString("AboutBox_Title")))
                {
                    form.ShowDialog();
                }
                return; // ❌ ERROR FATAL
            }

            Logger.Log(LocalizationManager.GetString("Log_AdminRightsConfirmed"));
            Logger.Log(LocalizationManager.GetString("Log_FindingCacheLocation"));

            string explorerCachePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Microsoft",
                "Windows",
                "Explorer"
            );

            if (!Directory.Exists(explorerCachePath))
            {
                Logger.Log(
                    LocalizationManager.GetString("Log_CachePathNotFound") + explorerCachePath,
                    true
                );
                return; // ❌ ERROR FATAL
            }

            Logger.Log(
                LocalizationManager.GetString("Log_CachePathFound") + explorerCachePath
            );

            // ============================
            // INTENTO DE CIERRE DE EXPLORER
            // ============================

            bool explorerWasRunning = ExplorerController.IsExplorerRunning();

            if (explorerWasRunning)
            {
                Logger.Log(LocalizationManager.GetString("Log_TerminatingExplorer"));
                Logger.Log(LocalizationManager.GetString("Log_AttemptingGracefulShutdown"));

                bool closedGracefully = ExplorerController.TryCloseExplorerGracefully();

                if (closedGracefully)
                {
                    Logger.Log(LocalizationManager.GetString("Log_ExplorerTerminatedGracefully"));
                }
                else
                {
                    Logger.Log(LocalizationManager.GetString("Log_GracefulShutdownFailed"));
                    Logger.Log(LocalizationManager.GetString("Log_AttemptingForceKill"));

                    bool forceClosed = ExplorerController.ForceKillExplorer();

                    if (forceClosed)
                    {
                        Logger.Log(LocalizationManager.GetString("Log_ExplorerForceKilled"));
                    }
                    else
                    {
                        // ✔️ ERROR RECUPERABLE (MUY IMPORTANTE)
                        Logger.Log(
                            LocalizationManager.GetString("Log_ForceKillFailedContinueCleanup"),
                            true
                        );
                    }
                }

                // Pequeña espera para liberar handles si algo se cerró
                Thread.Sleep(1000);
            }

            // ============================
            // ELIMINACIÓN DE ARCHIVOS DE CACHÉ
            // ============================

            Logger.Log(LocalizationManager.GetString("Log_DeletingCacheFiles"));

            int deletedCount = 0;

            try
            {
                var cacheFiles = Directory.GetFiles(
                    explorerCachePath,
                    "*.db",
                    SearchOption.AllDirectories
                ).Where(file =>
                    Path.GetFileName(file).StartsWith("IconCache", StringComparison.OrdinalIgnoreCase) ||
                    Path.GetFileName(file).StartsWith("thumbcache_", StringComparison.OrdinalIgnoreCase)
                );

                foreach (string file in cacheFiles)
                {
                    try
                    {
                        File.Delete(file);
                        deletedCount++;

                        Logger.Log(
                            $"{LocalizationManager.GetString("Log_DeletedFile")}: {Path.GetFileName(file)}"
                        );
                    }
                    catch (Exception ex)
                    {
                        // ✔️ ERROR RECUPERABLE
                        Logger.Log(
                            $"{LocalizationManager.GetString("Log_ErrorDeletingFile")}: {Path.GetFileName(file)} - {ex.Message}",
                            true
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                // ❌ ERROR FATAL
                Logger.Log(
                    LocalizationManager.GetString("Log_ErrorDuringDeletion") + ex.Message,
                    true
                );
                return;
            }

            if (deletedCount > 0)
            {
                Logger.Log(
                    LocalizationManager.GetString("Log_CacheFilesDeleted") + deletedCount
                );
            }
            else
            {
                Logger.Log(
                    LocalizationManager.GetString("Log_NoCacheFilesFoundToDelete")
                );
            }

            // ============================
            // REINICIO DE EXPLORER
            // ============================

            if (explorerWasRunning)
            {
                Logger.Log(LocalizationManager.GetString("Log_RestartingExplorer"));

                try
                {
                    ExplorerController.RestartExplorer();
                    Logger.Log(LocalizationManager.GetString("Log_ExplorerRestarted"));
                }
                catch
                {
                    Logger.Log(
                        LocalizationManager.GetString("Log_ManualRestartNeeded"),
                        true
                    );
                }
            }

            Logger.Log(LocalizationManager.GetString("Log_CleanupComplete"));
        }
    }
}