using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Diccionarios
{
	// Token: 0x02000373 RID: 883
	public abstract class DiccionarioDeReaccionBase<T_linea> : DiccionarioDeReaccionBase where T_linea : DiccionarioDeReaccionBase.LineaDeTextoBase
	{
		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x0600132E RID: 4910
		// (set) Token: 0x0600132F RID: 4911
		public abstract List<T_linea> lineasDeTexto { get; protected set; }

		// Token: 0x06001330 RID: 4912
		protected abstract T_linea ObtenerNuevaInstancia(string text);

		// Token: 0x06001331 RID: 4913 RVA: 0x000530F7 File Offset: 0x000512F7
		public override void ReordenarSegunChance()
		{
			this.lineasDeTexto.Sort((T_linea x, T_linea y) => x.chance.CompareTo(y.chance));
		}

		// Token: 0x06001332 RID: 4914 RVA: 0x00053124 File Offset: 0x00051324
		public override void AutoGenerar()
		{
			this.auto = this.auto.Trim();
			if (string.IsNullOrEmpty(this.auto))
			{
				return;
			}
			foreach (string text in this.auto.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
			{
				T_linea t_linea = this.ObtenerNuevaInstancia(text.Trim());
				this.lineasDeTexto.Add(t_linea);
			}
			this.auto = string.Empty;
		}

		// Token: 0x06001333 RID: 4915 RVA: 0x000531AC File Offset: 0x000513AC
		public override void RemoverRepetidos()
		{
			IEnumerable<T_linea> enumerable = from x in this.lineasDeTexto
				group x by x.texto into x
				select x.First<T_linea>();
			this.lineasDeTexto = new List<T_linea>(enumerable);
		}

		// Token: 0x06001334 RID: 4916 RVA: 0x00053214 File Offset: 0x00051414
		public override void RemoverVacios()
		{
			this.lineasDeTexto.ForEach(delegate(T_linea l)
			{
				l.texto.Trim();
			});
			this.lineasDeTexto.RemoveAll((T_linea l) => string.IsNullOrEmpty(l.texto));
		}
	}
}
