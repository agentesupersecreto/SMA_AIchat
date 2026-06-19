using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;
using Assets.TValle.Pro.Entrevista.Runtime.Menus.Maps;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.UI;
using Assets._ReusableScripts.Miscellaneous;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.TValle.Pro.Entrevista.Runtime.Menus.Globales
{
	// Token: 0x020000AE RID: 174
	public sealed class RadialMenusForActivities : AsyncSingleton<RadialMenusForActivities>
	{
		// Token: 0x0600066A RID: 1642 RVA: 0x0002567D File Offset: 0x0002387D
		protected override void InitSyncData(bool esEditorTime)
		{
			base.InitSyncData(esEditorTime);
			if (this.m_donaPrefab == null)
			{
				throw new ArgumentNullException("m_donaPrefab", "m_donaPrefab null reference.");
			}
		}

		// Token: 0x0600066B RID: 1643 RVA: 0x000256A4 File Offset: 0x000238A4
		protected override IEnumerator PostInitData()
		{
			this.m_menusPorKey = this.m_maps.ToDictionary((RadialMenusForActivities.MenuPar m) => m.id);
			yield break;
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x000256B4 File Offset: 0x000238B4
		public void InitRadialMenusOnFemale(Character character)
		{
			Transform boneTransform = character.bodyAnimator.GetBoneTransform(HumanBodyBones.Head);
			BaseFolowTransform componentInChildren = Object.Instantiate<GameObject>(this.m_donaPrefab, character.transform.position, character.transform.rotation, character.transform).GetComponentInChildren<BaseFolowTransform>();
			componentInChildren.transform.SetPositionAndRotation(boneTransform.position, boneTransform.rotation);
			if (componentInChildren.isStared)
			{
				componentInChildren.ResetOffsets();
				return;
			}
			componentInChildren.ManualStart();
		}

		// Token: 0x0600066D RID: 1645 RVA: 0x00025728 File Offset: 0x00023928
		public void RemoveAllRadialMenus(Character character)
		{
			ActivadorDeTHSDona componentInChildren = character.GetComponentInChildren<ActivadorDeTHSDona>();
			if (componentInChildren == null)
			{
				throw new ArgumentNullException("activadorDeDona", "activadorDeDona null reference.");
			}
			RadialMenusForActivities.RemoveAllMaps(character, componentInChildren.ownOpciones);
		}

		// Token: 0x0600066E RID: 1646 RVA: 0x00025764 File Offset: 0x00023964
		public void AddRadialMenus(Character character, params string[] ids)
		{
			for (int i = 0; i < ids.Length; i++)
			{
				this.AddRadialMenu(character, ids[i]);
			}
		}

		// Token: 0x0600066F RID: 1647 RVA: 0x0002578C File Offset: 0x0002398C
		public void AddRadialMenus(Character character, List<IClickableSelectableTHSDonaItem> result, params string[] ids)
		{
			for (int i = 0; i < ids.Length; i++)
			{
				IClickableSelectableTHSDonaItem clickableSelectableTHSDonaItem = this.AddRadialMenu(character, ids[i]);
				if (result != null)
				{
					result.Add(clickableSelectableTHSDonaItem);
				}
			}
		}

		// Token: 0x06000670 RID: 1648 RVA: 0x000257BC File Offset: 0x000239BC
		public IClickableSelectableTHSDonaItem AddRadialMenu(Character character, string id)
		{
			ActivadorDeTHSDona componentInChildren = character.GetComponentInChildren<ActivadorDeTHSDona>();
			if (componentInChildren == null)
			{
				throw new ArgumentNullException("activadorDeDona", "activadorDeDona null reference.");
			}
			RadialMenusForActivities.MenuPar menuPar;
			if (!this.m_menusPorKey.TryGetValue(id, out menuPar))
			{
				return null;
			}
			return RadialMenusForActivities.AddMapMenu(menuPar.menu, character, componentInChildren.ownOpciones);
		}

		// Token: 0x06000671 RID: 1649 RVA: 0x00025810 File Offset: 0x00023A10
		private static void RemoveAllMaps(Character character, LoaderDeTHSDona parent)
		{
			foreach (object obj in parent.transform)
			{
				Object.Destroy(((Transform)obj).gameObject);
			}
		}

		// Token: 0x06000672 RID: 1650 RVA: 0x0002586C File Offset: 0x00023A6C
		private static IClickableSelectableTHSDonaItem AddMapMenu(RadialMenuMap map, Character character, LoaderDeTHSDona parent)
		{
			if (map is PrefabRadialMenuMap)
			{
				GameObject gameObject = Object.Instantiate<GameObject>(((PrefabRadialMenuMap)map).prefab, character.transform.position, character.transform.rotation, parent.transform);
				gameObject.gameObject.SetActive(true);
				return gameObject.GetComponentInChildren<IClickableSelectableTHSDonaItem>();
			}
			if (map is GenericRadialMenuMap)
			{
				GenericRadialMenuMap genericRadialMenuMap = (GenericRadialMenuMap)map;
				SlaveOpcionDeTHSDona slaveOpcionDeTHSDona = parent.transform.CreateChild(genericRadialMenuMap.defaultText).gameObject.AddComponent<SlaveOpcionDeTHSDona>();
				slaveOpcionDeTHSDona.transform.SetPositionAndRotation(character.transform.position, character.transform.rotation);
				slaveOpcionDeTHSDona.SetMaster(genericRadialMenuMap);
				if (genericRadialMenuMap.subMenus.Count > 0)
				{
					LoaderDeTHSDona loaderDeTHSDona = slaveOpcionDeTHSDona.transform.CreateChild("Loader").gameObject.AddComponent<LoaderDeTHSDona>();
					slaveOpcionDeTHSDona.onOpcionClicked.AddListener(new UnityAction<THSDonaController.CurrentUserData, THSDonaController, THSDonaController.RadialItemData, object>(loaderDeTHSDona.DrawFromSelection));
					for (int i = 0; i < genericRadialMenuMap.subMenus.Count; i++)
					{
						RadialMenusForActivities.AddMapMenu(genericRadialMenuMap.subMenus[i], character, loaderDeTHSDona);
					}
				}
				return slaveOpcionDeTHSDona;
			}
			throw new ArgumentOutOfRangeException();
		}

		// Token: 0x040003EE RID: 1006
		[SerializeField]
		private GameObject m_donaPrefab;

		// Token: 0x040003EF RID: 1007
		[SerializeField]
		private RadialMenusForActivities.MenuPar[] m_maps;

		// Token: 0x040003F0 RID: 1008
		private Dictionary<string, RadialMenusForActivities.MenuPar> m_menusPorKey;

		// Token: 0x0200022E RID: 558
		[Serializable]
		public class MenuPar
		{
			// Token: 0x04000A8A RID: 2698
			public string id;

			// Token: 0x04000A8B RID: 2699
			public RadialMenuMap menu;
		}
	}
}
