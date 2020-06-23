﻿using System.Threading.Tasks;
using KevinAndJustinsBookStore.Features.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace KevinAndJustinsBookStore.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly SignInManager<User> signInManager;
        private readonly DataContext dataContext;
        private readonly UserManager<User> userManager;

        public CustomersController(UserManager<User> userManager, DataContext dataContext, SignInManager<User> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.dataContext = dataContext;
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser(CreateCustomerDto dto)
        {
            var newUser = new User
            {
                UserName = dto.Username,
                Email = dto.Email
                
            };

            // wrapping in a transaction means that if part of the transaction fails then everything saved is undone
            using (var transaction = await dataContext.Database.BeginTransactionAsync())
            {

                var identityResult = await userManager.CreateAsync(newUser, dto.Password);
                if (!identityResult.Succeeded)
                {
                    return BadRequest();
                }

                if(dto.Password != dto.PasswordConfirmed)
                {
                    return BadRequest();
                }

                if(dto.Email != dto.EmailConfirmed)
                {
                    return BadRequest();
                }

                var roleResult = await userManager.AddToRoleAsync(newUser, Roles.Customer);
                if (!roleResult.Succeeded)
                {
                    return BadRequest();
                }

                transaction.Commit(); // this marks our work as done

                await signInManager.SignInAsync(newUser, isPersistent: false);

                return Created(string.Empty, new UserDto
                {
                    Username = newUser.UserName
                });
            }
        }
    }
}