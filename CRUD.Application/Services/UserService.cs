using AutoMapper;
using CRUD.Application.DTOs;
using CRUD.Application.Interfaces;
using CRUD.Domain.Entities;
using CRUD.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepo userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> CreateUser(UserDto userDto)
        {
            var user = new Users
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Phone = userDto.Phone,
            };

            await _userRepository.Add(user);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var user = await _userRepository.GetById(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAll();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<bool> UpdateUser(UserDto userDto)
        {
            var existingUser = await _userRepository.GetById(userDto.Id);

            if (existingUser == null)
            {
                return false;
            }

            _mapper.Map(userDto, existingUser);
            _userRepository.Update(existingUser);
            return true;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var existingUser = await _userRepository.GetById(id);

            if (existingUser == null)
            {
                return false;
            }

            _userRepository.Delete(existingUser);
            return true;
        }
    }
}
