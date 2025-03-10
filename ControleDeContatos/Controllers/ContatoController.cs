﻿using AspNetCoreGeneratedDocument;
using ControleDeContatos.Filters;
using ControleDeContatos.Helper;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControleDeContatos.Controllers
{
    [PaginaParaUsuarioLogado]
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        private readonly ISessao _sessao;

        public ContatoController(IContatoRepositorio contatoRepositorio, 
                                 ISessao sessao)
        {
            _contatoRepositorio = contatoRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos(usuarioLogado.Id);

            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
           ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);


                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato Apagado com sucesso!";     
                }
                else
                {
                    TempData["MensagemErro"] = "Não conseguimos apagar seu contato";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Contato não foi Apagado, detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar (ContatoModel contato) 
        {
            try
            {
                if (ModelState.IsValid) //ta dizendo que é falso direito 
                {
                    UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                    contato.UsuarioId = usuarioLogado.Id;

                    contato = _contatoRepositorio.Adicionar(contato);

                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(contato);

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"opis não conseguimos cadastrar seu contato, tente novamente, detalhes do erro:{erro.Message}";
                return RedirectToAction("Index");  

            }
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                    contato.UsuarioId = usuarioLogado.Id;

                    contato = _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato Editado e salvo com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Editar", contato);// forçando acessar view Editar
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos editar seu contato, tente novamente, detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
