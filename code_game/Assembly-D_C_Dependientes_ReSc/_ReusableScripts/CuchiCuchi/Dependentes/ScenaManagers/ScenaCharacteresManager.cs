using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores.Mapas.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Globales.Updater;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.ScenaManagers
{
	// Token: 0x020000ED RID: 237
	public abstract class ScenaCharacteresManager : ScenaManager<ScenaCharacteresManager>
	{
		// Token: 0x0600049E RID: 1182 RVA: 0x0001C141 File Offset: 0x0001A341
		protected override void OnAwake()
		{
			base.OnAwake();
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x0001C149 File Offset: 0x0001A349
		protected override void OnDestroyed()
		{
			base.OnDestroyed();
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x0001C151 File Offset: 0x0001A351
		protected override void InitData(bool esEditorTime)
		{
			base.InitData(esEditorTime);
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x0001C15A File Offset: 0x0001A35A
		protected override void FinalizarData()
		{
			base.FinalizarData();
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x0001C164 File Offset: 0x0001A364
		[Obsolete("usar loader")]
		protected void BindMainCharacter(string nombreKey, string displayNombre, ICharacterIdentificable character)
		{
			if (character.isBinded)
			{
				Debug.LogWarning(string.Concat(new string[] { "Character: ", displayNombre, "/", nombreKey, " ya ha sido iniciado, tal vez hayan problemas" }), (Object)character);
			}
			character.Bind(displayNombre, displayNombre, string.Empty, Singleton<CollecionDeCharacteresIDs>.instance.IdDe(nombreKey).ToGuid());
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x00002BEA File Offset: 0x00000DEA
		[Obsolete("", true)]
		protected void BindCharacter(Guid ID, string nombre, ICharacterIdentificable character)
		{
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x00002BEA File Offset: 0x00000DEA
		[Obsolete("", true)]
		protected void BindCharacter(Guid ID, string nombre, string apellido, ICharacterIdentificable character)
		{
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x0001C1CC File Offset: 0x0001A3CC
		[Obsolete("usar loader")]
		protected void LoadAparienciaFisica(FemaleChar character, MapaDeAlteracionesAparienciaFemeninaBase mapa)
		{
			if (mapa == null)
			{
				return;
			}
			AlteradoresDeAparienciaFemenina componentEnRoot = character.GetComponentEnRoot<AlteradoresDeAparienciaFemenina>();
			if (componentEnRoot == null)
			{
				Debug.LogError("character no tiene alteradores", character);
				return;
			}
			componentEnRoot.mapaDeValores = mapa;
			componentEnRoot.flagToForceUpdateValores = true;
		}

		// Token: 0x060004A6 RID: 1190 RVA: 0x0001C210 File Offset: 0x0001A410
		[Obsolete("", true)]
		protected void LoadPersonalidad(FemaleChar character, MapaDeAlteracionesPersonalidadFemeninaBase mapa)
		{
			if (mapa == null)
			{
				return;
			}
			AlteradoresDePersonalidadFemenina componentEnRoot = character.GetComponentEnRoot<AlteradoresDePersonalidadFemenina>();
			if (componentEnRoot == null)
			{
				Debug.LogError("character no tiene alteradores", character);
				return;
			}
			componentEnRoot.mapaDeValores = mapa;
			componentEnRoot.flagToForceUpdateValores = true;
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x0001C251 File Offset: 0x0001A451
		protected sealed override void OnSceneCargada(LoadSceneMode arg1)
		{
			this.Onload(arg1);
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x0001C25A File Offset: 0x0001A45A
		protected sealed override void OnSceneDescargada()
		{
			this.OnUnload();
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x0001C262 File Offset: 0x0001A462
		protected void GameOverOnMax(Character character, ReaccionHumana reaccion)
		{
			EmocionesFemeninas componentEnRoot = character.GetComponentEnRoot<EmocionesFemeninas>();
			if (componentEnRoot == null)
			{
				throw new ArgumentNullException("emos", "emos null reference.");
			}
			componentEnRoot.ObtenerEmocion(reaccion).onMaxValue += this.OnGameOverPorMax;
		}

		// Token: 0x060004AA RID: 1194
		protected abstract void OnGameOverPorMax(Emocion emo);

		// Token: 0x060004AB RID: 1195 RVA: 0x0001C29C File Offset: 0x0001A49C
		[Obsolete("TODO: hacer version asyncona")]
		protected TRopa LoadFemaleRopa<TRopa>(FemaleChar character, string id) where TRopa : PiezaDeRopaBase
		{
			IRopaManager componentInChildren = character.GetComponentInChildren<IRopaManager>();
			if (componentInChildren == null)
			{
				throw new ArgumentNullException("adder", "adder null reference.");
			}
			TRopa added = default(TRopa);
			base.StartCoroutine(componentInChildren.AddPiezaAsync<TRopa>(id, null, delegate(TRopa a)
			{
				added = a;
			}, true));
			return default(TRopa);
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x0001C2FC File Offset: 0x0001A4FC
		protected T InstantiateInteraccionDynamica<T>(T original, Character character) where T : DatosDeInteraccionDynamica
		{
			IInteraccionesDeCharacter componentInChildren = character.GetComponentInChildren<IInteraccionesDeCharacter>();
			if (componentInChildren == null)
			{
				throw new ArgumentNullException("interacciones", "interacciones null reference.");
			}
			T t = Object.Instantiate<T>(original, character.transform);
			if (!componentInChildren.TryAddInteraction(t.interaccionID, t.interaccion))
			{
				Object.Destroy(t);
				throw new InvalidOperationException("no se pudo añadir interaccion " + original.interaccion.name);
			}
			return t;
		}

		// Token: 0x060004AD RID: 1197 RVA: 0x0001C378 File Offset: 0x0001A578
		protected void InstantiateInteraccionDynamica(GameObject prefab, Character character, float delay)
		{
			try
			{
				prefab.GetComponentsInChildren<DatosDeInteraccionDynamica>(true, this.m_tempDatosDeInteraccionDynamica);
				for (int i = 0; i < this.m_tempDatosDeInteraccionDynamica.Count; i++)
				{
					DatosDeInteraccionDynamica original = this.m_tempDatosDeInteraccionDynamica[i];
					if (delay < 0f)
					{
						this.InstantiateInteraccionDynamica<DatosDeInteraccionDynamica>(original, character);
					}
					else
					{
						GlobalUpdater.instancia.Invokar(delegate
						{
							this.InstantiateInteraccionDynamica<DatosDeInteraccionDynamica>(original, character);
						}, delay);
					}
				}
			}
			finally
			{
				this.m_tempDatosDeInteraccionDynamica.Clear();
			}
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x0001C434 File Offset: 0x0001A634
		protected void InstantiateInteraccionDynamica<T>(T original, Character character, float delay) where T : DatosDeInteraccionDynamica
		{
			if (delay < 0f)
			{
				this.InstantiateInteraccionDynamica<T>(original, character);
				return;
			}
			GlobalUpdater.instancia.Invokar(delegate
			{
				this.InstantiateInteraccionDynamica<T>(original, character);
			}, delay);
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x0001C490 File Offset: 0x0001A690
		protected ConversationTrigger InstantiateConversationTrigger(ConversationTrigger original, Vector3 position, Quaternion rotation, Transform parent, Vector3 scale, Transform conversant)
		{
			ConversationTrigger conversationTrigger = Object.Instantiate<ConversationTrigger>(original, position, rotation, parent);
			conversationTrigger.transform.localScale = scale;
			conversationTrigger.conversant = conversant;
			return conversationTrigger;
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x0001C4B4 File Offset: 0x0001A6B4
		protected void SetInitialInteraction(Character @char, InteracionPrimariaExterna interaction, float duration, int prioridad, float delay)
		{
			if (interaction == null)
			{
				return;
			}
			if (delay < 0f)
			{
				this.SetInitialInteraction(@char, interaction, duration, prioridad);
				return;
			}
			GlobalUpdater.instancia.Invokar(delegate
			{
				this.SetInitialInteraction(@char, interaction, duration, prioridad);
			}, delay);
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x0001C53B File Offset: 0x0001A73B
		private void SetInitialInteraction(Character @char, InteracionPrimariaExterna interaction, float duration, int prioridad)
		{
			if (@char.GetComponentInChildren<InteraccionesBasicasDeFemale>() == null)
			{
				return;
			}
			interaction.TryEjecutarOn(@char, prioridad, duration, ControllerPrioridadConfig.prioridad);
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x0001C558 File Offset: 0x0001A758
		protected void SetInitialInteraction(Character @char, InteraccionSegundariaName tipo, float duration, int prioridad, float delay)
		{
			if (tipo == InteraccionSegundariaName.None)
			{
				return;
			}
			if (delay < 0f)
			{
				this.SetInitialInteraction(@char, tipo, duration, prioridad);
				return;
			}
			GlobalUpdater.instancia.Invokar(delegate
			{
				this.SetInitialInteraction(@char, tipo, duration, prioridad);
			}, delay);
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x0001C5DC File Offset: 0x0001A7DC
		private void SetInitialInteraction(Character @char, InteraccionSegundariaName tipo, float duration, int prioridad)
		{
			InteraccionesBasicasDeFemale componentInChildren = @char.GetComponentInChildren<InteraccionesBasicasDeFemale>();
			if (componentInChildren == null)
			{
				return;
			}
			Interaccion interaccion;
			if (!componentInChildren.TryObtenerSiEsValida(tipo, out interaccion))
			{
				return;
			}
			interaccion.Ejecutar(prioridad, duration, ControllerPrioridadConfig.prioridad, 1f, 1f, false);
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x0001C61C File Offset: 0x0001A81C
		protected void SetInitialInteraction(Character @char, InteraccionPrimariaName tipo, float duration, int prioridad, float delay)
		{
			if (tipo == InteraccionPrimariaName.None)
			{
				return;
			}
			if (delay < 0f)
			{
				this.SetInitialInteraction(@char, tipo, duration, prioridad);
				return;
			}
			GlobalUpdater.instancia.Invokar(delegate
			{
				this.SetInitialInteraction(@char, tipo, duration, prioridad);
			}, delay);
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x0001C6A0 File Offset: 0x0001A8A0
		private void SetInitialInteraction(Character @char, InteraccionPrimariaName tipo, float duration, int prioridad)
		{
			InteraccionesBasicasDeFemale componentInChildren = @char.GetComponentInChildren<InteraccionesBasicasDeFemale>();
			if (componentInChildren == null)
			{
				return;
			}
			Interaccion interaccion;
			if (!componentInChildren.TryObtenerSiEsValida(tipo, out interaccion))
			{
				return;
			}
			interaccion.Ejecutar(prioridad, duration, ControllerPrioridadConfig.prioridad, 1f, 1f, false);
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x0001C6E0 File Offset: 0x0001A8E0
		protected void AddStaredListiner(CustomUpdatedMonobehaviourBase target, CustomMonobehaviourEventHandler callback)
		{
			if (callback == null)
			{
				throw new ArgumentNullException("callback", "callback null reference.");
			}
			if (target == null)
			{
				throw new ArgumentNullException("tipTarget", "tipTarget null reference.");
			}
			if (target.isStared)
			{
				callback(target);
				return;
			}
			target.stared += callback;
		}

		// Token: 0x060004B7 RID: 1207
		protected abstract void Onload(LoadSceneMode loadSceneMode);

		// Token: 0x060004B8 RID: 1208
		protected abstract void OnUnload();

		// Token: 0x04000398 RID: 920
		public const string conversationsParentName = "Conversaciones";

		// Token: 0x04000399 RID: 921
		[CoolArrayItem]
		public List<ScenaCharacteresManager.TransformRegistrado> transformRegistrados = new List<ScenaCharacteresManager.TransformRegistrado>();

		// Token: 0x0400039A RID: 922
		private List<Tuple<Character, string>> m_toChangeNames = new List<Tuple<Character, string>>();

		// Token: 0x0400039B RID: 923
		private List<DatosDeInteraccionDynamica> m_tempDatosDeInteraccionDynamica = new List<DatosDeInteraccionDynamica>();

		// Token: 0x020000EE RID: 238
		[Serializable]
		public class TransformRegistrado
		{
			// Token: 0x060004BA RID: 1210 RVA: 0x0001C759 File Offset: 0x0001A959
			public void Aplicar(Transform objetivo, bool incluirScala)
			{
				objetivo.SetPositionAndRotation(this.transform.position, this.transform.rotation);
				if (incluirScala)
				{
					this.transform.localScale = this.transform.lossyScale;
				}
			}

			// Token: 0x060004BB RID: 1211 RVA: 0x0001C790 File Offset: 0x0001A990
			public void Aplicar(Character objetivo)
			{
				objetivo.SetPositionAndRotation(this.transform.position, this.transform.rotation);
			}

			// Token: 0x0400039C RID: 924
			public int id;

			// Token: 0x0400039D RID: 925
			public Transform transform;
		}

		// Token: 0x020000EF RID: 239
		[Serializable]
		public struct InteraccionSegundariaPrioridadPar
		{
			// Token: 0x0400039E RID: 926
			public InteraccionSegundariaName interEnum;

			// Token: 0x0400039F RID: 927
			public int prioridad;
		}

		// Token: 0x020000F0 RID: 240
		[Serializable]
		public class EmocionesConfig
		{
			// Token: 0x060004BD RID: 1213 RVA: 0x0001C7B0 File Offset: 0x0001A9B0
			public void Load(Character target)
			{
				EmocionesFemeninas emocionesFemeninas = ((target != null) ? target.GetComponentInChildren<EmocionesFemeninas>() : null);
				if (emocionesFemeninas == null)
				{
					return;
				}
				for (int i = 0; i < this.emocionesIniciales.Count; i++)
				{
					ScenaCharacteresManager.EmocionesConfig.ReaccionValorPar reaccionValorPar = this.emocionesIniciales[i];
					Emocion emocion = emocionesFemeninas.ObtenerEmocion(reaccionValorPar.reaccion);
					if (!(emocion == null))
					{
						emocion.ChangeValueNextUpdate(reaccionValorPar.valor);
					}
				}
				for (int j = 0; j < this.emocionesMaximoValor.Count; j++)
				{
					ScenaCharacteresManager.EmocionesConfig.ReaccionValorPar reaccionValorPar2 = this.emocionesMaximoValor[j];
					emocionesFemeninas.config.limitesDeEmociones.SetLimiteMax(reaccionValorPar2.reaccion, reaccionValorPar2.valor);
				}
				for (int k = 0; k < this.emocionesMinimoValor.Count; k++)
				{
					ScenaCharacteresManager.EmocionesConfig.ReaccionValorPar reaccionValorPar3 = this.emocionesMinimoValor[k];
					emocionesFemeninas.config.limitesDeEmociones.SetLimiteMin(reaccionValorPar3.reaccion, reaccionValorPar3.valor);
				}
			}

			// Token: 0x040003A0 RID: 928
			public List<ScenaCharacteresManager.EmocionesConfig.ReaccionValorPar> emocionesIniciales;

			// Token: 0x040003A1 RID: 929
			public List<ScenaCharacteresManager.EmocionesConfig.ReaccionValorPar> emocionesMaximoValor;

			// Token: 0x040003A2 RID: 930
			public List<ScenaCharacteresManager.EmocionesConfig.ReaccionValorPar> emocionesMinimoValor;

			// Token: 0x020000F1 RID: 241
			[Serializable]
			public struct ReaccionValorPar
			{
				// Token: 0x040003A3 RID: 931
				public ReaccionHumana reaccion;

				// Token: 0x040003A4 RID: 932
				public float valor;
			}
		}
	}
}
