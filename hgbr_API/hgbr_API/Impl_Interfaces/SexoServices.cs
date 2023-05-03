using hgbr_API.Interfaces;
using hgbr_API.Models;
namespace hgbr_API.ImplInterfaces
{
	public class SexoService : ISexoService
    {
		private readonly HgbrContext context;

		public SexoService(HgbrContext context)
		{
			this.context = context;
		}

		/// Obtén un sexo por medio del identificador (ID) en objeto dedicado.
		public Sexo getSexoClass(int ID)
		{
			try
			{
				var lista = context.Sexos.Where(p => (int) p.Id == ID).FirstOrDefault();
				return lista;
			} catch (System.Exception)
			{
				throw;
			}
		}

		public object getSexo(int ID)
		{
			try
			{
				var result = context.Sexos.Where(p => (int)p.Id == ID).Select(sexo => new
				{
					idSexo = sexo.Id,
					nombre = sexo.Nombre
				}).First();
				return result;
			} catch (System.Exception)
			{
				throw;
			}
		}


		public IEnumerable<Sexo> GetAll()
		{
			try
			{
				var lista = context.Sexos.ToList();
				return lista.Select(s => {
					return s;
				});
			} catch ( System.Exception )
			{
				throw;
			}
		}
	}
}