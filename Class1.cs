using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using Data_L;

namespace Business_L
{
    internal enum enMode
    {
        Add_New, Update
    }

    public class clsBook
    {
        enMode _mode;
        public int Id { private set; get; }
        public string Title { set; get; }
        public string Author { set; get; }
        public string Genre { set; get; }
        public DateTime PublishDate { set; get; }
        public int Copies { set; get; }
        public int Publisher_ID { set; get; }


        private clsBook(int Id, string Title, string Author, string Genre, DateTime PublishDate,
             int Copies, int Publisher_ID)
        {
            this.Id = Id;
             this.Author = Author;
            this.Title = Title;
            this.Genre = Genre;
            this.PublishDate = PublishDate;
            this.Copies = Copies;
            this.Publisher_ID = Publisher_ID;

            _mode = enMode.Update;
        }

        public clsBook()
        {
            Id = -1;
            _mode = enMode.Add_New;
        }

        public static clsBook Find(int id)
        {
            int pub_id = -1,copies=0;
            DateTime pubDate = DateTime.MinValue;
            string author = "", title = "", genre = "";

            return Data_L.clsBook.Find(id,ref title,ref author,ref genre, ref pubDate,ref copies, ref pub_id)
                ? new clsBook(id,title,author,genre,pubDate,copies,pub_id):null;
        }
        private bool _AddBook()
        {

         int  id = Data_L.clsBook.AddNewBook(Title,Author,Genre,PublishDate,Copies,Publisher_ID);
            return id != -1;

        }

        private bool _UpdateBook()
        {
            return Data_L.clsBook.UpdateBook(this.Id,Title,Author,Genre,PublishDate,Copies,Publisher_ID);
        }
        public static bool DeleteBook(int id) { return Data_L.clsBook.DeleteBook(id); }
        public static DataTable ListAllBooks()
        {
            return Data_L.clsBook.ListAllBooks();
        }
        public static bool IsBookPresent(int id)
        {
            return Data_L.clsBook.IsBookPresent(id);
        }
        public bool Save() // to ensure the DRY principle 
        {
            // valid ? proceed: false;
            switch (this._mode)
            {
                case enMode.Add_New:
                    {
                        if (_AddBook() ) 
                        {
                            _mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }

                case enMode.Update:
                    {
                        return _UpdateBook();
                    }

                default: return true; // should extend ofc

            }

        }


    }


    public class clsEmployee
    {
        enMode _mode;
        public int Id { private set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public DateTime HireD { set; get; }
        public int Salary { set; get; } //ofc could be decimal but ya know no one is paid in fractions :)
        public int shiftid { set; get; }


        private clsEmployee(int Id, string FirstName, string LastName, DateTime HireD,
             int Salary, int shiftid)
        {
            this.Id = Id;
           this.FirstName = FirstName;  
           this.LastName = LastName;
            this.HireD = HireD;
            this.Salary = Salary;
            this.shiftid = shiftid;

            _mode = enMode.Update;
        }

        public clsEmployee()
        {
            Id = -1;
            _mode = enMode.Add_New;
        }

        public static clsEmployee Find(int id)
        {
            int shiftId = -1,Salary  = 0;
            DateTime HireD = DateTime.MinValue;
            string firstname = "", lastname = "";

            return Data_L.clsEmployee.Find(id, ref firstname, ref lastname, ref HireD,ref Salary,ref shiftId)
                ? new clsEmployee(id,  firstname,  lastname,  HireD,  Salary,  shiftId) : null;
        }
        private bool _AddEmployee()
        {
            int id = Data_L.clsEmployee.AddNewEmployee(FirstName,LastName,HireD,Salary,shiftid);
            return id != -1;
        }

        private bool _UpdateEmployee()
        {
            return Data_L.clsEmployee.UpdateEmployee(Id,FirstName, LastName, HireD, Salary, shiftid);
        }
        public static bool DeleteEmployee(int id) { return Data_L.clsEmployee.DeleteEmployee(id); }
        public static DataTable ListAllEmployees()
        {
            return Data_L.clsEmployee.ListAllEmployees();
        }
        public static bool IsEmployeePresent(int id)
        {
            return Data_L.clsEmployee.IsEmployeePresent(id);
        }
        public bool Save() // to ensure the DRY principle 
        {
            // valid ? proceed: false;
            switch (this._mode)
            {
                case enMode.Add_New:
                    {
                        if (_AddEmployee())
                        {
                            _mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }

                case enMode.Update:
                    {
                        return _UpdateEmployee();
                    }

                default: return true; // should extend ofc

            }

        }

    }
    public class clsLoan
    {
        enMode _mode;
        public int Id { private set; get; }

        public DateTime LoanD { set; get; }
        public DateTime DueD { set; get; }
        public int MemberId { set; get; }
        public int BookId { set; get; } 


        private clsLoan(int Id, int MemberId, int BookId, DateTime LoanD,
             DateTime DueD)
        {
            this.Id = Id;
            this.MemberId = MemberId;
            this.BookId = BookId;
            this.LoanD = LoanD;
            this.DueD = DueD;
            _mode = enMode.Update;
        }

        public clsLoan()
        {
            Id = -1;
            _mode = enMode.Add_New;
        }

        public static clsLoan Find(int id)
        {
            int MemberId = -1, BookId = -1;
            DateTime loanD = DateTime.MinValue;
            DateTime dueD = DateTime.MinValue;


            return Data_L.clsLoan.Find(id,ref MemberId,ref BookId,ref loanD,ref dueD)
                ? new clsLoan(id, MemberId, BookId, loanD, dueD) : null;
        }
        private bool _AddLoan()
        {
            int id = Data_L.clsLoan.AddNewLoan(MemberId,BookId,LoanD,DueD);
            return id != -1;
        }

        private bool _UpdateLoan()
        {
            return Data_L.clsLoan.UpdateLoan(Id,MemberId,BookId,LoanD,DueD);
        }
        public static bool DeleteLoan(int id) { return Data_L.clsLoan.DeleteLoan(id); }
        public static DataTable ListAllLoans()
        {
            return Data_L.clsLoan.ListAllLoans();
        }
        public static bool IsLoanPresent(int id)
        {
            return Data_L.clsLoan.IsLoanPresent(id);
        }
        public bool Save() // to ensure the DRY principle 
        {
            // valid ? proceed: false;
            switch (this._mode)
            {
                case enMode.Add_New:
                    {
                        if (_AddLoan())
                        {
                            _mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }

                case enMode.Update:
                    {
                        return _UpdateLoan();
                    }

                default: return true; // should extend ofc

            }

        }
    }
    public class clsMember
    {

        enMode _mode;
        public int Id { private set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public DateTime JoinD { set; get; }
        public DateTime EndMem { set; get; } 


        private clsMember(int Id, string FirstName, string LastName, DateTime JoinD,
            DateTime EndMem)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.JoinD = JoinD;
            this.EndMem = EndMem;

            _mode = enMode.Update;
        }

        public clsMember()
        {
            Id = -1;
            _mode = enMode.Add_New;
        }

        public static clsMember Find(int id)
        {
            
            DateTime JoinD = DateTime.MinValue;
            DateTime EndMem = DateTime.MinValue;

            string firstname = "", lastname = "";

            return Data_L.clsMember.Find(id, ref firstname, ref lastname, ref JoinD, ref EndMem)
                ? new clsMember(id, firstname, lastname, JoinD, EndMem) : null;
        }
        private bool _AddMember()
        {
            int id = Data_L.clsMember.AddNewMember(FirstName, LastName, JoinD, EndMem);
            return id != -1;
        }

        private bool _UpdateMember()
        {
            return Data_L.clsMember.UpdateMember(Id, FirstName, LastName,JoinD,EndMem);
        }
        public static bool DeleteMember(int id) { return Data_L.clsMember.DeleteMember(id); }
        public static DataTable ListAllMembers()
        {
            return Data_L.clsMember.ListAllMembers();
        }
        public static bool IsMemberPresent(int id)
        {
            return Data_L.clsMember.IsMemberPresent(id);
        }
        public bool Save() // to ensure the DRY principle 
        {
            // valid ? proceed: false;
            switch (this._mode)
            {
                case enMode.Add_New:
                    {
                        if (_AddMember())
                        {
                            _mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }

                case enMode.Update:
                    {
                        return _UpdateMember();
                    }

                default: return true; // should extend ofc

            }

        }



    }
}
