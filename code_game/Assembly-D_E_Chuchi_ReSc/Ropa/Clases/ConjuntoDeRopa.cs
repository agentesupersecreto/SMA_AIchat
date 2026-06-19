using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Tools.Runtime.Clothing;
using Assets._ReusableScripts.UI;
using Assets._ReusableScripts.UI.Modales.Globales;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa.Clases
{
	// Token: 0x0200014B RID: 331
	[Serializable]
	public class ConjuntoDeRopa : IConjuntoDeRopa, IConjuntoDeRopaMutable
	{
		// Token: 0x0600077A RID: 1914 RVA: 0x00023308 File Offset: 0x00021508
		public static ConjuntoDeRopa FromOutif(ITValleOutfit outfit)
		{
			ConjuntoDeRopa conjuntoDeRopa = new ConjuntoDeRopa();
			conjuntoDeRopa.serialVersionPiezas = 2;
			conjuntoDeRopa.serialVersionMateriales = 2;
			foreach (ITVallePiecesOfClothing itvallePiecesOfClothing in outfit.pieces)
			{
				Pieza pieza = new Pieza();
				pieza.ropaIDString = itvallePiecesOfClothing.ID;
				conjuntoDeRopa.piezas.Add(pieza);
				foreach (ITValleClothingMaterial itvalleClothingMaterial in itvallePiecesOfClothing.slotMaterial)
				{
					SlotDeMaterialDeRopa slotDeMaterialDeRopa = new SlotDeMaterialDeRopa();
					slotDeMaterialDeRopa.SetMaterialID(itvalleClothingMaterial.ID);
					slotDeMaterialDeRopa.materialSlot = itvalleClothingMaterial.slotIndex;
					slotDeMaterialDeRopa.añadirUnaCopia = true;
					slotDeMaterialDeRopa.color = itvalleClothingMaterial.color;
					pieza.materiales.Add(slotDeMaterialDeRopa);
				}
			}
			return conjuntoDeRopa;
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x0600077B RID: 1915 RVA: 0x00023408 File Offset: 0x00021608
		IReadOnlyList<Pieza> IConjuntoDeRopa.piezas
		{
			get
			{
				return this.piezas;
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x0600077C RID: 1916 RVA: 0x00023410 File Offset: 0x00021610
		string IConjuntoDeRopa.name
		{
			get
			{
				return this.name;
			}
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x0600077D RID: 1917 RVA: 0x00023410 File Offset: 0x00021610
		// (set) Token: 0x0600077E RID: 1918 RVA: 0x00023418 File Offset: 0x00021618
		string IConjuntoDeRopaMutable.name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x0600077F RID: 1919 RVA: 0x00023408 File Offset: 0x00021608
		// (set) Token: 0x06000780 RID: 1920 RVA: 0x00023421 File Offset: 0x00021621
		List<Pieza> IConjuntoDeRopaMutable.piezas
		{
			get
			{
				return this.piezas;
			}
			set
			{
				this.piezas = value;
			}
		}

		// Token: 0x06000781 RID: 1921 RVA: 0x0002342C File Offset: 0x0002162C
		public static bool VerificarYCorregirIntegridadPiezas(ConjuntoDeRopa conjunto, ref List<Pieza> missingPiezas, List<MapaDeRopa.RopaData> dataColectadaSoloValidos = null)
		{
			RopaParaAvatarUnificado instance = AsyncSingleton<RopaParaAvatarUnificado>.instance;
			if (missingPiezas == null)
			{
				missingPiezas = new List<Pieza>();
			}
			if (missingPiezas.Count > 0)
			{
				missingPiezas.Clear();
			}
			int num = conjunto.serialVersionPiezas;
			int num2 = ((dataColectadaSoloValidos != null) ? dataColectadaSoloValidos.Count : 0);
			for (int i = conjunto.piezas.Count - 1; i >= 0; i--)
			{
				Pieza pieza = conjunto.piezas[i];
				MapaDeRopa.RopaData ropaData = null;
				if (num > 1)
				{
					if (num == 2)
					{
						ropaData = instance.ObtenerData(pieza.ropaIDString);
					}
				}
				else
				{
					string text = instance.ConvertirID(pieza.ropaID_OLD);
					if (!string.IsNullOrWhiteSpace(text))
					{
						ropaData = instance.ObtenerData(text);
						if (ropaData != null)
						{
							pieza.ropaIDString = text;
						}
					}
				}
				if (ropaData == null)
				{
					conjunto.piezas.RemoveAt(i);
					missingPiezas.Add(pieza);
				}
				else if (dataColectadaSoloValidos != null)
				{
					dataColectadaSoloValidos.Insert(num2, ropaData);
				}
			}
			conjunto.serialVersionPiezas = 2;
			return missingPiezas.Count == 0;
		}

		// Token: 0x06000782 RID: 1922 RVA: 0x00023520 File Offset: 0x00021720
		public static bool VerificarYCorregirIntegridadPiezasConMsg(ConjuntoDeRopa conjunto, List<MapaDeRopa.RopaData> dataColectadaSoloValidos = null)
		{
			List<Pieza> list = null;
			bool flag = ConjuntoDeRopa.VerificarYCorregirIntegridadPiezas(conjunto, ref list, dataColectadaSoloValidos);
			for (int i = 0; i < list.Count; i++)
			{
				Pieza pieza = list[i];
				Singleton<MainCanvas>.instance.MostrartMsg("Missing Asset", string.Concat(new string[]
				{
					"Clothing with ID: ",
					pieza.ropaIDString,
					" | ",
					pieza.ropaID_OLD.ToString(),
					"  has not loaded into the game."
				}), 10f, true, null, null, null);
				Singleton<ModalWindow>.instance.AcumularErrores(string.Concat(new string[]
				{
					"Clothing with ID: ",
					pieza.ropaIDString,
					" | ",
					pieza.ropaID_OLD.ToString(),
					"  has not loaded into the game."
				}), null);
			}
			return flag;
		}

		// Token: 0x06000783 RID: 1923 RVA: 0x0002360C File Offset: 0x0002180C
		public static bool VerificarYCorregirIntegridadMateriales(ConjuntoDeRopa conjunto, ref List<SlotDeMaterialDeRopa> missingMaterials, List<List<MaterialParaRopaData>> dataColectadaTodos = null)
		{
			MaterialesParaRopa instance = AsyncSingleton<MaterialesParaRopa>.instance;
			if (missingMaterials == null)
			{
				missingMaterials = new List<SlotDeMaterialDeRopa>();
			}
			if (missingMaterials.Count > 0)
			{
				missingMaterials.Clear();
			}
			int num = conjunto.serialVersionMateriales;
			for (int i = 0; i < conjunto.piezas.Count; i++)
			{
				Pieza pieza = conjunto.piezas[i];
				List<MaterialParaRopaData> list = null;
				if (dataColectadaTodos != null)
				{
					list = new List<MaterialParaRopaData>();
					dataColectadaTodos.Add(list);
				}
				for (int j = 0; j < pieza.materiales.Count; j++)
				{
					SlotDeMaterialDeRopa slotDeMaterialDeRopa = pieza.materiales[j];
					MaterialParaRopaData materialParaRopaData = null;
					if (num > 1)
					{
						if (num == 2)
						{
							materialParaRopaData = instance.ObtenerData(slotDeMaterialDeRopa.materialIDString);
						}
					}
					else
					{
						string text = instance.ConvertirID(slotDeMaterialDeRopa.materialID_OLD);
						if (!string.IsNullOrWhiteSpace(text))
						{
							materialParaRopaData = instance.ObtenerData(text);
							if (materialParaRopaData != null)
							{
								slotDeMaterialDeRopa.SetMaterialID(text);
							}
						}
					}
					if (materialParaRopaData == null)
					{
						missingMaterials.Add(slotDeMaterialDeRopa);
					}
					if (list != null)
					{
						list.Add(materialParaRopaData);
					}
				}
			}
			conjunto.serialVersionMateriales = 2;
			return missingMaterials.Count == 0;
		}

		// Token: 0x06000784 RID: 1924 RVA: 0x00023724 File Offset: 0x00021924
		public static bool VerificarYCorregirIntegridadMaterialesConMsg(ConjuntoDeRopa conjunto, List<List<MaterialParaRopaData>> dataColectadaTodos = null)
		{
			List<SlotDeMaterialDeRopa> list = null;
			bool flag = ConjuntoDeRopa.VerificarYCorregirIntegridadMateriales(conjunto, ref list, dataColectadaTodos);
			for (int i = 0; i < list.Count; i++)
			{
				SlotDeMaterialDeRopa slotDeMaterialDeRopa = list[i];
				Singleton<MainCanvas>.instance.MostrartMsg("Missing Asset", string.Concat(new string[]
				{
					"Clothing Material with ID: ",
					slotDeMaterialDeRopa.materialIDString,
					" | ",
					slotDeMaterialDeRopa.materialID_OLD.ToString(),
					"  has not loaded into the game."
				}), 10f, true, null, null, null);
				Singleton<ModalWindow>.instance.AcumularErrores(string.Concat(new string[]
				{
					"Clothing Material with ID: ",
					slotDeMaterialDeRopa.materialIDString,
					" | ",
					slotDeMaterialDeRopa.materialID_OLD.ToString(),
					"  has not loaded into the game."
				}), null);
			}
			return flag;
		}

		// Token: 0x040005FA RID: 1530
		public const int lastSerializedVersion = 2;

		// Token: 0x040005FB RID: 1531
		public string name;

		// Token: 0x040005FC RID: 1532
		[CoolArrayItem]
		public List<Pieza> piezas = new List<Pieza>();

		// Token: 0x040005FD RID: 1533
		public int serialVersionPiezas;

		// Token: 0x040005FE RID: 1534
		public int serialVersionMateriales;
	}
}
