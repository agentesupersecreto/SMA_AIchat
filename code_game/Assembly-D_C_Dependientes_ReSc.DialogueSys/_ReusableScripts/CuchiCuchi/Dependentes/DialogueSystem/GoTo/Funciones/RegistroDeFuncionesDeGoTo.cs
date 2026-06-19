using System;
using System.Linq;
using System.Reflection;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Navigation;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.GoTo.UI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.ScenaManagers;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.AI;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.GoTo.Funciones
{
	// Token: 0x02000050 RID: 80
	public class RegistroDeFuncionesDeGoTo : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x0600025B RID: 603 RVA: 0x0000C53D File Offset: 0x0000A73D
		static RegistroDeFuncionesDeGoTo()
		{
			LuaAutoRegisterAttribute.Load(MethodBase.GetCurrentMethod().DeclaringType);
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0000C550 File Offset: 0x0000A750
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			LuaAutoRegisterAttribute.Register(this);
			Lua.RegisterFunction("GoToEsTurnAround", this, base.GetType().GetMethod("GoToEsTurnAround"));
			Lua.RegisterFunction("GotoArticulo", this, base.GetType().GetMethod("GotoArticulo"));
			Lua.RegisterFunction("GotoNombre", this, base.GetType().GetMethod("GotoNombre"));
			Lua.RegisterFunction("GotoEsTurnedAroundToApply", this, base.GetType().GetMethod("GotoEsTurnedAroundToApply"));
			Lua.RegisterFunction("GotoKeyToApply", this, base.GetType().GetMethod("GotoKeyToApply"));
			Lua.RegisterFunction("PuedeNavegarAGoTo", this, base.GetType().GetMethod("PuedeNavegarAGoTo"));
		}

		// Token: 0x0600025D RID: 605 RVA: 0x0000C60C File Offset: 0x0000A80C
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			LuaAutoRegisterAttribute.Unregister(this);
			Lua.UnregisterFunction("GoToEsTurnAround");
			Lua.UnregisterFunction("GotoArticulo");
			Lua.UnregisterFunction("GotoNombre");
			Lua.UnregisterFunction("GotoEsTurnedAroundToApply");
			Lua.UnregisterFunction("GotoKeyToApply");
			Lua.UnregisterFunction("PuedeNavegarAGoTo");
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0000C664 File Offset: 0x0000A864
		[LuaAutoRegister]
		public int GetSelectedRecostarseID(string id)
		{
			int num;
			try
			{
				Guid guid = Guid.Parse(id);
				Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				OpcionesDeTHSDonaDeRecostarseisponiblesQueIniciaDialogoNext componentInChildren = character.GetComponentInChildren<OpcionesDeTHSDonaDeRecostarseisponiblesQueIniciaDialogoNext>();
				OpcionesDeTHSDonaDeRecostarseisponiblesQueIniciaDialogoPrev componentInChildren2 = character.GetComponentInChildren<OpcionesDeTHSDonaDeRecostarseisponiblesQueIniciaDialogoPrev>();
				if (!componentInChildren.isSelected && !componentInChildren2.isSelected)
				{
					Debug.LogError("ninguna fue seleccionada");
					num = 0;
				}
				else if (componentInChildren.isSelected)
				{
					num = (int)componentInChildren.selectedAnimID;
				}
				else if (componentInChildren2.isSelected)
				{
					num = (int)componentInChildren2.selectedAnimID;
				}
				else
				{
					Debug.LogError("las dos aparecen como seleccionadas");
					num = 0;
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num = 0;
			}
			return num;
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0000C6FC File Offset: 0x0000A8FC
		[LuaAutoRegister]
		public void Recostarse(string id, float animID)
		{
			try
			{
				Guid guid = Guid.Parse(id);
				FemaleAnimController componentEnRoot = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentEnRoot<FemaleAnimController>();
				int num = Mathf.RoundToInt(animID);
				if (num > 0)
				{
					componentEnRoot.RecostarseEnCurrentRecostable((FemaleAnimatedRecostarseIDs)num);
				}
				else
				{
					componentEnRoot.LevantarseDeCurrentRecostable();
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0000C758 File Offset: 0x0000A958
		public bool GoToEsTurnAround(string id)
		{
			bool flag;
			try
			{
				Guid guid = Guid.Parse(id);
				flag = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<OpcionesDeTHSDonaDeGoToDisponibles>().esTurnAround;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000261 RID: 609 RVA: 0x0000C7A0 File Offset: 0x0000A9A0
		public string GotoArticulo(string id)
		{
			string text2;
			try
			{
				Guid guid = Guid.Parse(id);
				string text = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<OpcionesDeTHSDonaDeGoToDisponibles>().selectedKeys.Last<string>();
				GoToScenaManager.GoTo goTo = Singleton<GoToScenaManager>.instance.Obtener(text);
				text2 = ObtenerDialogosUtil.ObtenerArticuloDeterminado(goTo.nombrable.esPlural, goTo.nombrable.esFemenino, DireccionDeEstimulo.recibida);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text2 = "ERROR";
			}
			return text2;
		}

		// Token: 0x06000262 RID: 610 RVA: 0x0000C81C File Offset: 0x0000AA1C
		public string GotoNombre(string id)
		{
			string text2;
			try
			{
				Guid guid = Guid.Parse(id);
				string text = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<OpcionesDeTHSDonaDeGoToDisponibles>().selectedKeys.Last<string>();
				text2 = Singleton<GoToScenaManager>.instance.Obtener(text).nombrable.ObtenerNombreDeCurrentLocalization(NombrableResult.lower);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text2 = "ERROR";
			}
			return text2;
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0000C884 File Offset: 0x0000AA84
		public string GotoKeyToApply(string id)
		{
			string text;
			try
			{
				Guid guid = Guid.Parse(id);
				text = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<OpcionesDeTHSDonaDeGoToDisponibles>().selectedKeys.Last<string>();
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x06000264 RID: 612 RVA: 0x0000C8D4 File Offset: 0x0000AAD4
		public bool GotoEsTurnedAroundToApply(string id)
		{
			bool flag;
			try
			{
				Guid guid = Guid.Parse(id);
				Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				OpcionesDeTHSDonaDeGoToDisponibles componentInChildren = character.GetComponentInChildren<OpcionesDeTHSDonaDeGoToDisponibles>();
				if (componentInChildren.esTurnAround)
				{
					flag = !componentInChildren.esTurnedAround;
				}
				else
				{
					string text = componentInChildren.selectedKeys.Last<string>();
					GoToScenaManager.GoTo goTo = Singleton<GoToScenaManager>.instance.Obtener(text);
					if (!goTo.canTurnAround)
					{
						flag = false;
					}
					else
					{
						Character current = MainChar.current;
						Object @object;
						if (current == null)
						{
							@object = null;
						}
						else
						{
							Animator bodyAnimator = current.bodyAnimator;
							@object = ((bodyAnimator != null) ? bodyAnimator.transform : null);
						}
						if (@object == null)
						{
							flag = Random.value > 0.5f;
						}
						else
						{
							Vector3 vector = MainChar.current.bodyAnimator.transform.position - goTo.transform.position;
							Vector3 vector2 = goTo.transform.rotation * Vector3.forward;
							float num = Vector3.Angle(vector, vector2);
							Personalidad componentEnRoot = character.GetComponentEnRoot<Personalidad>();
							if (componentEnRoot == null || !componentEnRoot.timido)
							{
								flag = num > 90f;
							}
							else
							{
								flag = num < 90f;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0000CA14 File Offset: 0x0000AC14
		public bool PuedeNavegarAGoTo(string id)
		{
			bool flag;
			try
			{
				Guid guid = Guid.Parse(id);
				Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				string text = character.GetComponentInChildren<OpcionesDeTHSDonaDeGoToDisponibles>().selectedKeys.Last<string>();
				Vector3 position = Singleton<GoToScenaManager>.instance.Obtener(text).transform.position;
				Vector3 position2 = character.bodyAnimator.transform.position;
				if (SimpleFemaleNavigation.Navigator.IsOnTarget(position2, 1f, position, character.escala))
				{
					flag = true;
				}
				else
				{
					this.path = new NavMeshPath();
					if (!SimpleFemaleNavigation.Navigator.Find(this.path, position2, 1f, position, character.escala, 1f) || this.path.corners.Length == 0)
					{
						flag = false;
					}
					else
					{
						flag = Vector3.Distance(this.path.corners[this.path.corners.Length - 1], position) < 0.4f;
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = true;
			}
			finally
			{
				this.path = null;
			}
			return flag;
		}

		// Token: 0x040000F6 RID: 246
		private NavMeshPath path;
	}
}
