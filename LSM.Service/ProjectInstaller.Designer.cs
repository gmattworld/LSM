namespace LSM.Service
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LSM_Service_Installer = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstaller2 = new System.ServiceProcess.ServiceInstaller();
            // 
            // LSM_Service_Installer
            // 
            this.LSM_Service_Installer.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.LSM_Service_Installer.Password = null;
            this.LSM_Service_Installer.Username = null;
            // 
            // serviceInstaller2
            // 
            this.serviceInstaller2.ServiceName = "LSM_Service";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.LSM_Service_Installer,
            this.serviceInstaller2});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller LSM_Service_Installer;
        private System.ServiceProcess.ServiceInstaller serviceInstaller1;
        private System.ServiceProcess.ServiceInstaller serviceInstaller2;
    }
}