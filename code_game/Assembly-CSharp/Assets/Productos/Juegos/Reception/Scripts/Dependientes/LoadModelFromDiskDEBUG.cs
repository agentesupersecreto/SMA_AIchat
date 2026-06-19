using System;
using System.Text;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.Genetica.NPCs;
using Assets._ReusableScripts.Memorias.Archivos;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Dependientes
{
	// Token: 0x020000B7 RID: 183
	public class LoadModelFromDiskDEBUG : AplicableCustomMonobehaviour
	{
		// Token: 0x0600041B RID: 1051 RVA: 0x00014B02 File Offset: 0x00012D02
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Load"
			};
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x00014B1C File Offset: 0x00012D1C
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			Texture2D texture2D;
			byte[] array;
			SaveLoadCharacters.Cargar(this.fileName, out texture2D, out array);
			try
			{
				string text;
				if (SaveLoadCharacters.CustomDataIsZipped(array))
				{
					text = Zipiry.Unzip(array);
				}
				else
				{
					text = Encoding.UTF8.GetString(array);
				}
				TargetChar instance = TargetChar.instance;
				MemoriaJsonGenerica memoriaJsonGenerica = new MemoriaJsonGenerica();
				memoriaJsonGenerica.root.Load(text);
				ISujetoIdentificableNpc sujetoIdentificableNpc = MemoriaDeSujetosNpcFemenina.LeerNpcEnMemoriaFirstOrDefault(memoriaJsonGenerica);
				LoaderDeNpcFemeninos.Load(instance.character, sujetoIdentificableNpc, true, memoriaJsonGenerica, false);
			}
			finally
			{
				Object.Destroy(texture2D);
			}
		}

		// Token: 0x040001CC RID: 460
		public string fileName;
	}
}
