using System;
using System.Text;
using Assets.Base.Behaviours.Runtime.Cameras;
using Assets.Productos.Juegos.Reception;
using Assets.TValle.BeachGirl;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.Genetica.NPCs;
using Assets._ReusableScripts.Memorias.Archivos;
using UnityEngine;

namespace Assets.Productos.Juegos.Scripts.BeachGirl.Testing
{
	// Token: 0x02000092 RID: 146
	[RequireComponent(typeof(CameraRendingTextureTakeAPhoto))]
	public class LoadSaveImageCharacterTesting : AplicableCustomMonobehaviour
	{
		// Token: 0x060002EF RID: 751 RVA: 0x000108E1 File Offset: 0x0000EAE1
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_CameraRendingTextureTakeAPhoto = base.GetComponent<CameraRendingTextureTakeAPhoto>();
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x000108F8 File Offset: 0x0000EAF8
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.lastSaved != null)
			{
				Object.Destroy(this.lastSaved);
			}
			this.lastSaved = null;
			if (this.lastLoaded != null)
			{
				Object.Destroy(this.lastLoaded);
			}
			this.lastLoaded = null;
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x0001094C File Offset: 0x0000EB4C
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Save a Character"
			};
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x00010968 File Offset: 0x0000EB68
		protected override void OnAplicar2()
		{
			if (this.lastSaved != null)
			{
				Object.Destroy(this.lastSaved);
			}
			this.lastSaved = null;
			TargetChar instance = TargetChar.instance;
			IFemaleChar femaleChar = ((instance != null) ? instance.character : null) as IFemaleChar;
			ICharacterIdentificable characterIdentificable = ((femaleChar != null) ? femaleChar.self : null) as ICharacterIdentificable;
			if (femaleChar == null || characterIdentificable == null)
			{
				return;
			}
			Texture2D texture2D = null;
			if (!this.m_CameraRendingTextureTakeAPhoto.TryTakeAPhoto(ref texture2D, false))
			{
				return;
			}
			ISujetoIdentificableNpc newNPCAssetFromCharacter = LoaderDeNpcFemeninos.GetNewNPCAssetFromCharacter(characterIdentificable, true);
			if (newNPCAssetFromCharacter == null)
			{
				throw new NotSupportedException("Por ahora solo se puede guardar sujetos de la piscina actual");
			}
			MemoriaJsonGenerica memoriaJsonGenerica = new MemoriaJsonGenerica();
			MemoriaDeSujetosNpcFemenina.EscribirNpcAMemoriaCompleto(memoriaJsonGenerica, newNPCAssetFromCharacter, null);
			LoaderDeNpcFemeninos.SaveToMemory(memoriaJsonGenerica, characterIdentificable);
			byte[] bytes = Encoding.UTF8.GetBytes(memoriaJsonGenerica.root.Save());
			newNPCAssetFromCharacter.Destruir();
			SaveLoadCharacters.Guardar(characterIdentificable.nombreCompleto, texture2D, bytes);
			this.lastSaved = texture2D;
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x00010A36 File Offset: 0x0000EC36
		protected override CustomMonobehaviourBotonConfig Boton3()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Load a Character"
			};
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x00010A50 File Offset: 0x0000EC50
		protected override void OnAplicar3()
		{
			if (this.lastLoaded != null)
			{
				Object.Destroy(this.lastLoaded);
			}
			this.lastLoaded = null;
			if (string.IsNullOrWhiteSpace(this.nameToLoad))
			{
				return;
			}
			TargetChar instance = TargetChar.instance;
			if (instance == null)
			{
				return;
			}
			Texture2D texture2D;
			byte[] array;
			SaveLoadCharacters.Cargar(this.nameToLoad, out texture2D, out array);
			if (SaveLoadCharacters.CustomDataIsZipped(array))
			{
				this.customDataToLoaded = Zipiry.Unzip(array);
			}
			else
			{
				this.customDataToLoaded = Encoding.UTF8.GetString(array);
			}
			MemoriaJsonGenerica memoriaJsonGenerica = new MemoriaJsonGenerica();
			memoriaJsonGenerica.root.Load(this.customDataToLoaded);
			ISujetoIdentificableNpc sujetoIdentificableNpc = MemoriaDeSujetosNpcFemenina.LeerNpcEnMemoriaFirstOrDefault(memoriaJsonGenerica);
			LoaderDeNpcFemeninos.Load(instance.character, sujetoIdentificableNpc, true, memoriaJsonGenerica, false);
			this.lastLoaded = texture2D;
		}

		// Token: 0x04000145 RID: 325
		private CameraRendingTextureTakeAPhoto m_CameraRendingTextureTakeAPhoto;

		// Token: 0x04000146 RID: 326
		public string nameToLoad;

		// Token: 0x04000147 RID: 327
		[TextArea]
		public string customDataToLoaded;

		// Token: 0x04000148 RID: 328
		public Texture2D lastSaved;

		// Token: 0x04000149 RID: 329
		public Texture2D lastLoaded;
	}
}
