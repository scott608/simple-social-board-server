using SimpleSocialBoardServer.Areas.Member.Models.DTOs;
using SimpleSocialBoardServer.Data;
using SimpleSocialBoardServer.Areas.Member.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace SimpleSocialBoardServer.Core.auth.Services
{
      public class AuthService(MainDbContext db)
    {
        private readonly MainDbContext _db = db ?? throw new ArgumentNullException(nameof(db));


    }


}