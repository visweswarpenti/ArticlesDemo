using System;
using Xunit;
using Moq;
using ArticlesProject.Controllers;
using ArticlesProject.Repository;
using ArticlesProject.DatabaseEntities;
using ArticlesProject.Repository.Interfaces;
using System.Text.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ArticlesProject.UnitTest
{
	public class UnitTest1
	{
        [Fact]
        public void Test1()
        {
            string userList = @"[{'userId': 1,'userName': 'viswa','password': 'viswa',
    'address': 'viswa address',
    'contactNo': '903242424234'
  },
  {
    'userId': 2,
    'userName': 'manish',
    'password': 'manish',
    'address': 'manish address',
    'contactNo': '988347583475'
  },
  {
    'userId': 3,
    'userName': 'ray',
    'password': 'ray',
    'address': 'ray address',
    'contactNo': '53485438345'
  },
  {
    'userId': 4,
    'userName': 'jan',
    'password': 'jan',
    'address': 'jan address',
    'contactNo': '345345435345'
  }
]";


            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            Mock<IUserRepository> mockRepositoyUser = new Mock<IUserRepository>();

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;

            var data = System.Text.Json.JsonSerializer.Deserialize<List<User>>(JsonPrettify(userList), options);
            mockRepositoyUser.Setup(obj => obj.GetAll()).Returns(data);
            mockUnitOfWork.Setup(obj => obj.UserRepo).Returns(mockRepositoyUser.Object);
            UserController userController = new UserController(mockUnitOfWork.Object);
            var result = userController.Get().Result as OkObjectResult;

            Assert.Equal(result.Value, data);

            var temp = data.Where(new Func<User, bool>(check));

            data.Any();
        }

        private static bool check(User user)
        {
            if (user.UserId > 1)
            {
                return true;
            }
            return false;
        }


        public static string JsonPrettify(string json)
        {
            using (var stringReader = new StringReader(json))
            using (var stringWriter = new StringWriter())
            {
                var jsonReader = new JsonTextReader(stringReader);
                var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = Formatting.Indented };
                jsonWriter.WriteToken(jsonReader);
                return stringWriter.ToString();
            }
        }

    }
}
