using Controle_de_Contatos.Models;
using Controle_de_Contatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Controle_de_Contatos.Controllers
{
	public class ContatoController : Controller
	{
		private readonly IContatoRepositorio _contatoRepositorio;

		public ContatoController(IContatoRepositorio contatoRepositorio)
		{
			_contatoRepositorio = contatoRepositorio;
		}

		public IActionResult Index()
		{
			List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
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
					TempData["MensagemSucesso"] = "Contato apagado com sucesso!";
				} else
				{
					TempData["MensagemErro"] = "Ops, não conseguimos apagar seu contato!";
				}

				return RedirectToAction("Index");
			}
			catch (Exception error)
			{
				TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu contato. Detalhe do erro: {error.Message}";
				return RedirectToAction("Index");
			}
		}

		[HttpPost]
		public IActionResult Criar(ContatoModel contato)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_contatoRepositorio.Adicionar(contato);
					TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
					return RedirectToAction("Index");
				}

				return View(contato);
			}
			catch (Exception error)
			{
				TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu contato. Por favor, tente novamente. Detalhes do erro: {error.Message}";
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
					_contatoRepositorio.Atualizar(contato);
					TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
					return RedirectToAction("Index");
				}

				return View("Editar", contato);
			}
			catch (Exception error)
			{
				TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu contato. Por favor, tente novamente. Detalhes do erro: {error.Message}";
				return RedirectToAction("Index");
			}
		}
	}
}
