
using Firebase.Database.Query;
using static EScan.Includes.GlobalVariables;

namespace EScan.Model
{
    class User
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public async Task<bool> AddUser(string frname, string lsname, string uname, string pword)
        {
            var user = new User()
            {
                Firstname = frname,
                Lastname = lsname,
                Username = uname,
                Password = pword,
            };
            await client.Child("User").PostAsync(user);
            return true;
        }
        public async Task<bool> EditUserAd(string frname, string lsname, string uname, string pword, string stat, string flename)
        {

            var user = new User()
            {
                Firstname = frname,
                Lastname = lsname,
                Username = uname,
                Password = pword,
            };
            await client.Child($"User/{userkey}").PatchAsync(user);
            return true;
        }
        public async Task<bool> GetUsername(string _uname)
        {
            try
            {
                var evaluateUsername = (await client.Child("User")
                .OnceAsync<User>()).FirstOrDefault(a =>
                a.Object.Username == _uname);


                if (evaluateUsername == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public async Task<List<User>> GetUsers()
        {
            return (await client
                .Child("User")
                .OnceAsync<User>()).Select(item => new User
                {
                    Firstname = item.Object.Firstname,
                    Lastname = item.Object.Lastname,
                    Username = item.Object.Username,

                }).ToList();
        }

        public async Task<String> GetStatus(string _user)
        {
            var evaluateID = (await client.Child("User")
            .OnceAsync<User>()).FirstOrDefault
            (a => a.Object.Username == _user);
            if (evaluateID != null)
            {

                _password = evaluateID.Object.Password;
                _username = evaluateID.Object.Username;
                _userfname = evaluateID.Object.Firstname;
                _userlname = evaluateID.Object.Lastname;
                userkey = evaluateID.Key;

                return evaluateID.Key;
            }
            return null;
        }

        public async Task<bool> DeleteUser(string user)
        {
            try
            {

                var getuserkey = (await client
                    .Child("User")
                    .OnceAsync<User>()).FirstOrDefault
                    (a => a.Object.Username == user);
                if (getuserkey != null)
                {
                    await client
                        .Child("User")
                    .Child(getuserkey.Key)
                        .DeleteAsync();
                    client.Dispose();
                   
                    return true;
                }

                client.Dispose();
                return false;
            }
            catch
            {
                client.Dispose();
                return false;
            }
        }
        public async Task<bool> GetUser(string _uname, string _pword)
        {
            try
            {
                var evaluateUsername = (await client.Child("User")
                .OnceAsync<User>()).FirstOrDefault(b =>
                b.Object.Username == _uname && b.Object.Password == _pword);


                if (evaluateUsername != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        
        public async Task<bool> EditUser(string frname, string lsname, string uname, string pword)
        {
            var user = new User()
            {
                Firstname = frname,
                Lastname = lsname,
                Username = uname,
                Password = pword,
            };
            await GetStatus(uname);
            await client.Child($"User/{userkey}").PatchAsync(user);

            return true;
        }
        public async Task<List<User>> GetAllUsers()
        {

            return (await client
            .Child("User")
            .OnceAsync<User>()).Select(item => new User
            {
                Firstname = item.Object.Firstname,
                Lastname = item.Object.Lastname,
                Username = item.Object.Username,
            }).ToList();
        }

        public async Task<List<User>> FindUser(string fname)
        {
            var queryUsers = await GetAllUsers();
            await client
                .Child("User")
                .OnceAsync<User>();
            var searchTerms = fname.Split(' ');
            return queryUsers.Where(a => searchTerms.Any(term => a.Firstname.ToLower().Contains(term.ToLower()) || a.Username.ToLower().Contains(term.ToLower()) || a.Lastname.ToLower().Contains(term.ToLower())

            )).ToList();

        }
    }
}

