using Testing;

namespace Testing
{
    public class UserDatas
    {
        public void AllDatas()
        {
        public List<string> userName = new List<string>();
        public List<string> userSecondName = new List<string>();
        public List<string> userEmail = new List<string>();
        public List<string> userPassword = new List<string>();
    }
}
}

internal class Program
{
    static void Main(string[] args)
    {
        UserDatas UD = new UserDatas();
        UD.AllDatas();

        int login = 0;

        while (true)
        {
            string option;
            if (login == 0)
            {
                Console.Write("Which option do you need?  1.Register  3.Exit : ");
                option = Console.ReadLine()!;
            }
            else
            {
                Console.Write("Which option do you need?  1.Register  2.Login  3.Exit : ");
                option = Console.ReadLine()!;
            }

            if (option == "1" || option == "Register")
            {
                while (true)
                {
                    Console.Write("Pls enter first name : ");
                    string inputName = Console.ReadLine()!;

                    if (inputName.Length > 3 || inputName.Length < 30)
                    {
                        userName.Add(inputName);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Some informations are incorrect!");
                        Console.WriteLine();
                    }
                }

                while (true)
                {
                    Console.Write("Pls enter second name : ");
                    string inputSecondName = Console.ReadLine()!;

                    if (inputSecondName.Length < 20 || inputSecondName.Length > 5)
                    {
                        userSecondName.Add(inputSecondName);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Some informations are incorrect!");
                        Console.WriteLine();
                    }
                }

                while (true)
                {
                    bool check = false;
                    Console.Write("Pls enter email : ");
                    string inputEmail = Console.ReadLine()!;

                    for (int i = 0; i < inputEmail.Length; i++)
                    {
                        if (inputEmail[i] == '@')
                        {
                            for (int j = 0; j < inputEmail.Length; j++)
                            {
                                if (inputEmail[j] == '.')
                                {
                                    userEmail.Add(inputEmail);
                                    check = true;
                                    break;
                                }
                            }
                        }
                        if (check)
                        {
                            break;
                        }
                    }
                    if (check)
                    {
                        break;
                    }
                    Console.WriteLine("Some informations are incorrect!");
                    Console.WriteLine();
                }

                while (true)
                {
                    Console.WriteLine("Pls create a password : ");
                    string firstPassword = Console.ReadLine()!;
                    Console.WriteLine("Pls enter your password again : ");
                    string secondPassword = Console.ReadLine()!;

                    if (firstPassword == secondPassword)
                    {
                        string password = firstPassword;
                        userPassword.Add(password);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Some informations are incorrect!");
                        Console.WriteLine();
                    }
                }
            }
            else if (option == "2" || option == "Login")
            {
                bool checkAll = false;
                bool checkEmail = false;
                bool checkPassword = false;
                int checkBox = 0;

                while (true)
                {
                    Console.Write("Pls enter your email : ");
                    string email = Console.ReadLine()!;

                    Console.Write("Pls enter your password : ");
                    string password = Console.ReadLine()!;

                    foreach (string ValidEmail in userEmail)
                    {
                        if (ValidEmail == email)
                        {
                            for (int i = 0; i < userEmail.Count; i++)
                            {
                                if (userEmail[i] == email)
                                {
                                    checkBox = i; break;
                                }
                            }
                            checkEmail = true;
                        }
                    }

                    if (userPassword[checkBox] == password)
                    {
                        checkPassword = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Someting went wrong! Try again");
                        continue;
                    }
                }

                if (checkEmail && checkPassword)
                {
                    checkAll = true;
                }

                if (checkAll)
                {
                    Console.WriteLine($"Welcome {userName[checkBox]} {userSecondName[checkBox]}!");
                }
            }
            else if (option == "3" || option == "Exit")
            {
                Console.WriteLine("Thank you!");
                break;
            }

            login++;
        }
    }
}
}