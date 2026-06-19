using System;
using UnityEngine;

namespace Assets.TValle.Tools.Runtime.Moddding.Clothing.Maps
{
	// Token: 0x02000034 RID: 52
	[CreateAssetMenu(fileName = "MaterialMap", menuName = "TValle/Modding/Cloting/MaterialMap")]
	public class MaterialMap : ModdingMap
	{
		// Token: 0x04000075 RID: 117
		[Space]
		[Header("--- Material Data -----------------------------------------------------------------------")]
		[Space]
		[Tooltip("drop your unity material here. Remember that your material must be in the same group of addressables that corresponds to your mod")]
		public AssetReferenceMaterial materialAddress;

		// Token: 0x04000076 RID: 118
		[Space]
		[Header("--- Info -----------------------------------------------------------------------")]
		[Space]
		public ItemQuality itemQuality = ItemQuality.Rare;

		// Token: 0x04000077 RID: 119
		[Space]
		[Header("--- Outfit Generator Info -----------------------------------------------------------------------")]
		[Space]
		[Tooltip("probability that the generator will choose this item of material. (100% means that it will have the same opportunity as the rest of the materials that also have 100%, 50% means half, and so on).")]
		[Range(0f, 100f)]
		public float chance = 100f;

		// Token: 0x04000078 RID: 120
		[Tooltip("true if you want the generator to make a random color for this material. false if you don't want the color you set in the material to ever change.")]
		public bool canBeCustomColor = true;

		// Token: 0x04000079 RID: 121
		[Tooltip("true if you want the generator to set a random transparency, false if you want your material's transparency to always be the one you set.")]
		public bool canBeCustomOpacity;

		// Token: 0x0400007A RID: 122
		[Space]
		[Header("--- Optionals -----------------------------------------------------------------------")]
		[Space]
		[Tooltip("drop your Diffusion Profile here. EXPERIMENTAL: remember that your Diffusion Profile must be in the same group of addressables that corresponds to your mod")]
		public AssetReferenceDiffusionProfiles diffusionProfilesAddress;
	}
}
