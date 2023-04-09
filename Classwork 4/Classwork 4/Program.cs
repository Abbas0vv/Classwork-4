using Testing;

namespace Testing
{
    public class DataBase
    {
        public List<string> userName;
        public List<string> userSecondName;
        public List<string> userEmail;
        public List<string> userPassword;

        public DataBase()
        {
            userName = new List<string>();
            userSecondName = new List<string>();
            userEmail = new List<string>();
            userPassword = new List<string>();
        }
    }
    internal class Program
    {
        #region Menu
        static string Menu()
        {

            Console.Write("Which option do you need?  1.Register  2.Login  3.Exit : ");
            return Console.ReadLine()!;
        }
        #endregion

        static void Main(string[] args)
        {
            StartProgramLoop();
        }


        #region Starting Program
        static void StartProgramLoop()
        {
            while (true)
            {
                string choise = Menu();
                if (choise == "1" || choise == "Register")
                {
                    OperationOne();
                }
                else if (choise == "2" || choise == "Login")
                {
                    OperationTwo();
                }
                else if (choise == "3" || choise == "Exit")
                {
                    ExitCommand();
                    break;
                }
            }
        }
        #endregion

        #region First Operation
        static void OperationOne()
        {
            DataBase lists = new DataBase();

            lists.userName.Add(IsValidName());
            lists.userSecondName.Add(IsValidSecondName());
            lists.userEmail.Add(IsValidEmail());
            lists.userPassword.Add(IsValidPassword());
        }
        static string IsValidName()
        {
            Console.Write("Pls enter first name : ");
            string inputName = Console.ReadLine()!;

            while (true)
            {
                if (inputName.Length > 3 || inputName.Length < 30)
                {
                    return inputName;
                }
                else
                {
                    Console.WriteLine("Some informations are incorrect!");
                    Console.WriteLine();
                    Console.WriteLine("Pls enter first name : ");
                    inputName = Console.ReadLine()!;
                }
            }
        }
        static string IsValidSecondName()
        {
            Console.Write("Pls enter second name : ");
            string inputSecondName = Console.ReadLine()!;

            while (true)
            {
                if (inputSecondName.Length > 5 || inputSecondName.Length < 20)
                {
                    return inputSecondName;
                }
                else
                {
                    Console.WriteLine("Some informations are incorrect!");
                    Console.WriteLine();
                    Console.WriteLine("Pls enter second name");
                    inputSecondName = Console.ReadLine()!;
                }
            }
        }
        static string IsValidEmail()
        {
            Console.Write("Pls enter email : ");
            string inputEmail = Console.ReadLine()!;

            while (true)
            {
                for (int i = 0; i < inputEmail.Length; i++)
                {
                    if (inputEmail[i] == '@')
                    {
                        return inputEmail;
                    }
                }
                Console.WriteLine("Some informations are incorrect!");
                Console.WriteLine();
                Console.WriteLine("Pls enter email");
                inputEmail = Console.ReadLine()!;
            }
        }
        static string IsValidPassword()
        {
            Console.WriteLine("Pls create a password : ");
            string firstPassword = Console.ReadLine()!;
            Console.WriteLine("Pls enter your password again : ");
            string secondPassword = Console.ReadLine()!;

            while (true)
            {
                if (firstPassword == secondPassword)
                {
                    string password = firstPassword;
                    return password;
                }
                Console.WriteLine("Some informations are incorrect!");
                Console.WriteLine();
                Console.WriteLine("Pls create a password : ");
                firstPassword = Console.ReadLine()!;
                Console.WriteLine("Pls enter your password again : ");
                secondPassword = Console.ReadLine()!;
            }
        }
        #endregion

        #region Second Operation
        static void OperationTwo()
        {
            IsValidLogin();
        }
        static void IsValidLogin()
        {
            DataBase lists = new DataBase();
            DataBase dataBase = new DataBase();

            bool checkAll = false;
            bool checkEmail = false;
            bool checkPassword = false;
            int checkBox = -1;

            Console.Write("Pls enter your email : ");
            string email = Console.ReadLine()!;

            Console.Write("Pls enter your password : ");
            string password = Console.ReadLine()!;

            foreach (string ValidEmail in lists.userEmail)
            {
                if (ValidEmail == email)
                {
                    for (int i = 0; i < lists.userEmail.Count; i++)
                    {
                        if (lists.userEmail[i] == email)
                        {
                            checkEmail = true;
                            checkBox = i; 
                            break;
                        }
                    }
                }
            }

            if (checkBox != -1 && lists.userPassword[checkBox] == password)
            {
                checkPassword = true;
            }
            else
            {
                Console.WriteLine("Someting went wrong! Try again");
            }
            CompletedLogin(checkAll, checkEmail, checkPassword, checkBox, dataBase);
        }
        static void CompletedLogin(bool checkAll, bool checkEmail, bool checkPassword, int checkBox, DataBase dataBase)
        {
            IsValidEmail();

            if (checkEmail == true && checkPassword == true)
            {
                checkAll = true;
            }

            if (checkAll)
            {
                Console.WriteLine($"Welcome {dataBase.userName[checkBox]} {dataBase.userSecondName[checkBox]}!");
            }
            else
            {
                Console.WriteLine("Something went wrong!");
                Console.WriteLine();
                IsValidLogin();
            }
        }
        #endregion

        #region Last Operation
        static void ExitCommand()
        {
            Console.WriteLine("Thank you!");
        }
        #endregion
    }
}