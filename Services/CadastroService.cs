﻿using AutoMapper;
using ControleFinancas.Dtos;
using ControleFinancas.Models;
using Microsoft.AspNetCore.Identity;

namespace ControleFinancas.Services
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;

        public CadastroService(UserManager<Usuario> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task Cadastra(CreateUsuarioDto dto)
        {

            Usuario usuario = _mapper.Map<Usuario>(dto);

            IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Password);

            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Falha ao cadastrar o usuário!");
            }

        }
    }
}
