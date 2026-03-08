namespace Question3; 
partial class Login {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
        panel1 = new Panel();
        loginInputPage = new LoginInput();
        varifyPage = new VarifyPage();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // panel1
        // 
        resources.ApplyResources(panel1, "panel1");
        panel1.Controls.Add(loginInputPage);
        panel1.Name = "panel1";
        // 
        // loginInputPage
        // 
        resources.ApplyResources(loginInputPage, "loginInputPage");
        loginInputPage.Name = "loginInputPage";
        // 
        // Login
        // 
        resources.ApplyResources(this, "$this");
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(panel1);
        Name = "Login";
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();

        //
        // varifyPage
        //
        varifyPage.Name = "varifyPage";
    }

    #endregion

    private Panel panel1;
    private LoginInput loginInputPage;
    private VarifyPage varifyPage;
}
