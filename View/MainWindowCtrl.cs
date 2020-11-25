namespace ProyectoDIAIndep.View
{
    public class MainWindowCtrl {
        public MainWindowCtrl()
        {
            this.View = new MainWindowView();    
         
            this.View.OpQuit.Click += (o, args) => this.OnQuit();
            this.View.OpListLoan.Click += (o, args) => this.ViewListLoan();
            this.View.OpNewLoan.Click += (o, args) => this.ViewNewLoan();
            this.View.OpEditLoan.Click += (o, args) => this.ViewEditLoan();
            this.View.OpDelLoan.Click += (o, args) => this.ViewDelLoan();
            this.View.BtListLoan.Click += (o, args) => this.ViewListLoan();
            this.View.BtNewLoan.Click += (o, args) => this.ViewNewLoan();
            this.View.BtEditLoan.Click += (o, args) => this.ViewEditLoan();
            this.View.BtDelLoan.Click += (o, args) => this.ViewDelLoan();
        }
        
        void OnQuit()
        {
            this.View.Hide();
            this.View.Close();
        }

        void ViewListLoan()
        {
            new ListLoanCtrl().View.Show();
        }

        void ViewNewLoan()
        {
            new NewLoanCtrl().View.Show();
        }
        
        void ViewEditLoan()
        {
            new EditLoanCtrl().View.Show();
        }

        void ViewDelLoan()
        {
            new DelLoanCtrl().View.Show();
        }

        public MainWindowView View { get; }
    }
}