using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.TValle.Tools.Runtime.Moddding.Clothing.Maps
{
	// Token: 0x02000033 RID: 51
	[CreateAssetMenu(fileName = "ClothingItemMap", menuName = "TValle/Modding/Cloting/ClothingItemMap")]
	public class ClothingItemMap : ModdingMap
	{
		// Token: 0x0600011D RID: 285 RVA: 0x00003514 File Offset: 0x00001714
		protected override void OnValidate()
		{
			base.OnValidate();
			if (this.materialsPerIndex != null)
			{
				for (int i = 0; i < this.materialsPerIndex.Count; i++)
				{
					this.materialsPerIndex[i].materialIndex = i;
				}
			}
		}

		// Token: 0x0400005D RID: 93
		[Space]
		[Header("--- Clothing Item Data -----------------------------------------------------------------------")]
		[Space]
		[Tooltip("drop a renderer GameObject here. Remember that your clothing item must be in the same group of addressables that corresponds to your mod.")]
		public AssetReferenceGameObject address;

		// Token: 0x0400005E RID: 94
		[Tooltip("how deep this Clothing Item is.")]
		public ClothingItemMap.Layer layer = ClothingItemMap.Layer.clothes;

		// Token: 0x0400005F RID: 95
		[Tooltip("If any of the materials use tessellation, the game will set the distances and amounts. Set false if none of your materials uses tessellation or you want to configure it yourself; set true if you have any material with tessellation and you want the game to configure it.")]
		public bool gameConfigsTessellation;

		// Token: 0x04000060 RID: 96
		[Tooltip("If your mesh is not so complex and you want it to be able to collide against semen, set this to true. (Read/Write import settings MUST be on.)")]
		public bool canCollideAgainstSemen;

		// Token: 0x04000061 RID: 97
		[Tooltip("If the clothing item is rigid or not tight to the skin, for example, glasses, shoes, tails, horns, or some accessories, you can save performance by setting this option to true. (Read/Write import settings MUST be on.)")]
		public bool forceNoNormalRecalculation;

		// Token: 0x04000062 RID: 98
		[Tooltip("(Legacy)If your clothing item covers the breasts, it is advisable to select left and right breasts, the same for the buttocks, and the skin around the anus. if covers the breasts or ass, it dramatically improves the visual aspect of this clothing item. Remember that you need to have transfer the vertex-colors from the sample mesh to your clothing mesh.")]
		public ClothingItemMap.NormalRecalculators normalRecalculators;

		// Token: 0x04000063 RID: 99
		[Tooltip("MODIFY ONLY IF this Clothing Item has high heels.")]
		public ClothingItemMap.HeelConfig heelConfig = new ClothingItemMap.HeelConfig();

		// Token: 0x04000064 RID: 100
		[Tooltip("MODIFY ONLY IF this Clothing has a transformative effect on the bust.")]
		public ClothingItemMap.BreastConfig breastConfig = new ClothingItemMap.BreastConfig();

		// Token: 0x04000065 RID: 101
		[Tooltip("MODIFY ONLY IF this Clothing has a transformative effect on the ass.")]
		public ClothingItemMap.AssConfig assConfig = new ClothingItemMap.AssConfig();

		// Token: 0x04000066 RID: 102
		[Tooltip("MODIFY ONLY IF this Clothing has a transformative effect on the vagina.")]
		public ClothingItemMap.VaginaConfig vaginaConfig = new ClothingItemMap.VaginaConfig();

		// Token: 0x04000067 RID: 103
		[Tooltip("MODIFY ONLY IF this Clothing has a transformative effect on the anus.")]
		public ClothingItemMap.AnusConfig anusConfig = new ClothingItemMap.AnusConfig();

		// Token: 0x04000068 RID: 104
		[Space]
		[Header("--- Info -----------------------------------------------------------------------")]
		[Space]
		public ItemQuality itemQuality = ItemQuality.Rare;

		// Token: 0x04000069 RID: 105
		[Space]
		[Header("--- AI Info -----------------------------------------------------------------------")]
		[Space]
		[Tooltip("When asked to undress, where will the character be self-interacting? (TODO: only implemented torso and hips)")]
		public ClothingItemMap.SelfUndressingPosition selfUndressingPosition = ClothingItemMap.SelfUndressingPosition.torso;

		// Token: 0x0400006A RID: 106
		[Tooltip("select all body parts that this clothing item covers. If this clothing item is a subclotting item from an interacion, it needs to exclude at least one body part.")]
		public ClothingItemMap.Covers covers;

		// Token: 0x0400006B RID: 107
		[Space]
		[Header("--- Outfit Generator Info -----------------------------------------------------------------------")]
		[Space]
		[Tooltip("Since the male and female avatars are different, it is important to know which gender this piece of clothing is for when creating random outfits.")]
		public ClothingItemMap.Sex sex;

		// Token: 0x0400006C RID: 108
		[Tooltip("Are they underwear or stockings? either the upper body or lower body? It is important when creating random outfits.")]
		public ClothingItemMap.Type type;

		// Token: 0x0400006D RID: 109
		[Tooltip("probability that the generator will choose this item of clothing. (100% means that it will have the same opportunity as the rest of the clothes that also have 100%, 50% means half, and so on).")]
		[Range(0f, 100f)]
		public float chance = 100f;

		// Token: 0x0400006E RID: 110
		[Tooltip("if this clothing item does not go well with socks, set this to false.")]
		public bool canWearStockings = true;

		// Token: 0x0400006F RID: 111
		[Space(20f)]
		[Header("--- Clothing Materils Data-----------------------------------------------------------------------")]
		[Space]
		[Header("If this clothing item is a sub-clothing item,\nthis field can be left empty,\n and this clothing sub-item will inherit\n the materials of the parent clothing item.")]
		[Tooltip("Every single possible material combination must be declared here. If you don't want the game to have control over your materials, leave this empty.")]
		public List<ClothingItemMap.MaterialData> materialsPerIndex;

		// Token: 0x04000070 RID: 112
		[Space]
		[Header("--- Optionals -----------------------------------------------------------------------")]
		[Space]
		[Tooltip("If the surface of the clothing is too high above the skin, you need to add a little more distance, maybe one or two centimeters (0.01f, 0.02f)\r\n")]
		public float semenDistanceCastAdd;

		// Token: 0x04000071 RID: 113
		[Tooltip("EXPERIMENTAL: Create custom scripts implementing ICustomClothingItemScript and declare them here to be loaded into the game.")]
		public List<ClothingItemMap.CustomScript> customScripts;

		// Token: 0x04000072 RID: 114
		[Tooltip("thow a armature root GameObject. WARNING: Use ONLY if the piece of clothing has a custom armature, such as glasses, a skirt, a tail, etc., whose bones do not exist in the game yet. (You'll have to animate them yourself.")]
		public AssetReferenceGameObject customArmatureAddress;

		// Token: 0x04000073 RID: 115
		[Tooltip("WARNING: Use ONLY if the piece of clothing has a custom colliders, The game will turn these renders into colliders.")]
		public List<ClothingItemMap.CustomCollider> customColliders;

		// Token: 0x04000074 RID: 116
		[Space]
		[Header("--- Optionals: sub Clothing Items -----------------------------------------------------------------------")]
		[Space]
		[Tooltip("If this item of clothing has any sub-items, specify them here.")]
		public List<ClothingItemMap.Interaction> interactionsToSubClothingItems;

		// Token: 0x02000098 RID: 152
		[Serializable]
		public class HeelConfig
		{
			// Token: 0x0400027E RID: 638
			[Tooltip("In centimetres.")]
			public float toeHeigth;

			// Token: 0x0400027F RID: 639
			[Tooltip("In centimetres.")]
			public float heelHeigth;

			// Token: 0x04000280 RID: 640
			[Tooltip("Set this value to zero if you don't want the toes to rotate.(Experimental)")]
			[Range(0f, 1f)]
			public float toePoseWeigth = 1f;

			// Token: 0x04000281 RID: 641
			[Tooltip("Set this value to zero if you don't want the heels to rotate.(Experimental)")]
			[Range(0f, 1f)]
			public float heelPoseWeigth = 1f;
		}

		// Token: 0x02000099 RID: 153
		[Serializable]
		public class BreastConfig
		{
			// Token: 0x04000282 RID: 642
			[Range(1f, 4f)]
			[Tooltip("If this clothing item supports the breasts or pushes them up, increase this value.")]
			public float siffnessModifier = 1f;

			// Token: 0x04000283 RID: 643
			[Range(0.25f, 1f)]
			[Tooltip("If this clothing item has a rigid cup, decrease this value.")]
			public float nippleProjectionModifier = 1f;

			// Token: 0x04000284 RID: 644
			[Tooltip("If the nipple shape is obscured by this clothing item, leave this value at -1; if the nipple shape is fully visible, leave it at 1.")]
			[Range(-1f, 1f)]
			public float nippleShapeModifier = 1f;

			// Token: 0x04000285 RID: 645
			[Tooltip("If this clothing item pushes the breasts together, decrease this value.")]
			[Range(0f, 1f)]
			public float distanceBetweenModifier = 1f;
		}

		// Token: 0x0200009A RID: 154
		[Serializable]
		public class AssConfig
		{
			// Token: 0x04000286 RID: 646
			[Range(1f, 4f)]
			[Tooltip("If this clothing item supports the ass or pushes it up, increase this value.")]
			public float siffnessModifier = 1f;
		}

		// Token: 0x0200009B RID: 155
		[Serializable]
		public class VaginaConfig
		{
			// Token: 0x04000287 RID: 647
			[Tooltip("If this item of clothing pushes the labia of the vagina inward, increase this value.")]
			[Range(0f, 1f)]
			public float labiaShrinker;

			// Token: 0x04000288 RID: 648
			[Tooltip("If this clothing item squeezes together the labia of the vagina, increase this value.")]
			[Range(0f, 1f)]
			public float shrinker;

			// Token: 0x04000289 RID: 649
			[Tooltip("If this clothing item hides the wear on the vagina, decrease this value.")]
			[Range(0f, 1f)]
			public float wearModifier = 1f;
		}

		// Token: 0x0200009C RID: 156
		[Serializable]
		public class AnusConfig
		{
			// Token: 0x0400028A RID: 650
			[Tooltip("If this clothing item hides the wear on the anus, decrease this value.")]
			[Range(0f, 1f)]
			public float wearModifier = 1f;
		}

		// Token: 0x0200009D RID: 157
		[Serializable]
		public class Interaction
		{
			// Token: 0x0400028B RID: 651
			[Tooltip("In order to transform this garment into this sub-garment, which interaction animation must be executed?")]
			public ClothingItemMap.InterationsAnimation animation;

			// Token: 0x0400028C RID: 652
			[Tooltip("Drop the sub-garment's map here. Keep in mind that this sub-map and its associated assets must be placed in the same modding package or group.")]
			public ClothingItemMap subClothingItemMap;

			// Token: 0x0400028D RID: 653
			[Tooltip("When the interaction animation is running, which shape in the mesh should be active?")]
			public string toSubClothingItemShapeName;

			// Token: 0x0400028E RID: 654
			[Tooltip("When activating the shape morph on a sub-garment, there may be visible unwanted results; specify here what corrective shapes your mesh has.")]
			public List<ClothingItemMap.Interaction.CorrectiveShapes> corrections = new List<ClothingItemMap.Interaction.CorrectiveShapes>();

			// Token: 0x020000AE RID: 174
			[Serializable]
			public class CorrectiveShapes
			{
				// Token: 0x04000308 RID: 776
				[Tooltip("a zero-to-one animation curve, where t is the weight of the zero-to-one animation, meaning that the maximum value of this curve must be one and the time too.")]
				public AnimationCurve inOut1x1Curve;

				// Token: 0x04000309 RID: 777
				[Tooltip("When the correction is running, which shape in the mesh should be active?")]
				public string correctiveShapeName;
			}
		}

		// Token: 0x0200009E RID: 158
		[Flags]
		public enum NormalRecalculators
		{
			// Token: 0x04000290 RID: 656
			None = 0,
			// Token: 0x04000291 RID: 657
			leftBreast = 1,
			// Token: 0x04000292 RID: 658
			rightBreast = 2,
			// Token: 0x04000293 RID: 659
			leftGluteus = 4,
			// Token: 0x04000294 RID: 660
			rightGluteus = 8,
			// Token: 0x04000295 RID: 661
			leftAnusOpening = 16,
			// Token: 0x04000296 RID: 662
			rightAnusOpening = 32
		}

		// Token: 0x0200009F RID: 159
		public enum InterationsAnimation
		{
			// Token: 0x04000298 RID: 664
			None,
			// Token: 0x04000299 RID: 665
			exposeLegL,
			// Token: 0x0400029A RID: 666
			exposeLegR,
			// Token: 0x0400029B RID: 667
			exposeAssL,
			// Token: 0x0400029C RID: 668
			exposeAssR,
			// Token: 0x0400029D RID: 669
			exposeAssSideL,
			// Token: 0x0400029E RID: 670
			exposeAssSideR,
			// Token: 0x0400029F RID: 671
			exposeVagAnusL,
			// Token: 0x040002A0 RID: 672
			exposeVagAnusR,
			// Token: 0x040002A1 RID: 673
			exposeNipplesL,
			// Token: 0x040002A2 RID: 674
			exposeNipplesR = 0,
			// Token: 0x040002A3 RID: 675
			exposeShouldersL = 11,
			// Token: 0x040002A4 RID: 676
			exposeShouldersR,
			// Token: 0x040002A5 RID: 677
			exposeAssHalf1L,
			// Token: 0x040002A6 RID: 678
			exposeAssHalf1R,
			// Token: 0x040002A7 RID: 679
			exposeAssHalf2L,
			// Token: 0x040002A8 RID: 680
			exposeAssHalf2R,
			// Token: 0x040002A9 RID: 681
			pullDownAssHalf1L,
			// Token: 0x040002AA RID: 682
			pullDownAssHalf1R,
			// Token: 0x040002AB RID: 683
			pullDownAssHalf2L,
			// Token: 0x040002AC RID: 684
			pullDownAssHalf2R,
			// Token: 0x040002AD RID: 685
			exposeCrotchF,
			// Token: 0x040002AE RID: 686
			pullDownAssL,
			// Token: 0x040002AF RID: 687
			pullDownAssR,
			// Token: 0x040002B0 RID: 688
			exposeTorsoHalf1F,
			// Token: 0x040002B1 RID: 689
			exposeTorsoHalf2F,
			// Token: 0x040002B2 RID: 690
			exposeTorsoHalf1B,
			// Token: 0x040002B3 RID: 691
			exposeTorsoHalf2B,
			// Token: 0x040002B4 RID: 692
			exposeChestLateralHalf1L,
			// Token: 0x040002B5 RID: 693
			exposeChestLateralHalf1R,
			// Token: 0x040002B6 RID: 694
			exposeChestLateralHalf2L,
			// Token: 0x040002B7 RID: 695
			exposeChestLateralHalf2R,
			// Token: 0x040002B8 RID: 696
			exposeHipsHalf1L,
			// Token: 0x040002B9 RID: 697
			exposeHipsHalf1R,
			// Token: 0x040002BA RID: 698
			exposeHipsHalf2L,
			// Token: 0x040002BB RID: 699
			exposeHipsHalf2R = 34
		}

		// Token: 0x020000A0 RID: 160
		public enum Sex
		{
			// Token: 0x040002BD RID: 701
			None,
			// Token: 0x040002BE RID: 702
			male,
			// Token: 0x040002BF RID: 703
			female
		}

		// Token: 0x020000A1 RID: 161
		public enum Type
		{
			// Token: 0x040002C1 RID: 705
			None,
			// Token: 0x040002C2 RID: 706
			lowerBodyUnderwear,
			// Token: 0x040002C3 RID: 707
			upperBodyUnderwear,
			// Token: 0x040002C4 RID: 708
			upperBodyUnderwearAccessories = 11,
			// Token: 0x040002C5 RID: 709
			lowerBodyUnderwearAccessories,
			// Token: 0x040002C6 RID: 710
			lowerBody = 3,
			// Token: 0x040002C7 RID: 711
			upperBody,
			// Token: 0x040002C8 RID: 712
			shoes,
			// Token: 0x040002C9 RID: 713
			jacket,
			// Token: 0x040002CA RID: 714
			swimsuit,
			// Token: 0x040002CB RID: 715
			accessories = 9,
			// Token: 0x040002CC RID: 716
			glasses,
			// Token: 0x040002CD RID: 717
			socks = 8,
			// Token: 0x040002CE RID: 718
			gloves = 13,
			// Token: 0x040002CF RID: 719
			hat
		}

		// Token: 0x020000A2 RID: 162
		public enum Layer
		{
			// Token: 0x040002D1 RID: 721
			underUnderwear,
			// Token: 0x040002D2 RID: 722
			underwear,
			// Token: 0x040002D3 RID: 723
			underClothes,
			// Token: 0x040002D4 RID: 724
			clothes,
			// Token: 0x040002D5 RID: 725
			underAccessories,
			// Token: 0x040002D6 RID: 726
			accessories,
			// Token: 0x040002D7 RID: 727
			underCoat,
			// Token: 0x040002D8 RID: 728
			coat
		}

		// Token: 0x020000A3 RID: 163
		public enum SelfUndressingPosition
		{
			// Token: 0x040002DA RID: 730
			None,
			// Token: 0x040002DB RID: 731
			torso,
			// Token: 0x040002DC RID: 732
			hips,
			// Token: 0x040002DD RID: 733
			scalp,
			// Token: 0x040002DE RID: 734
			eyes,
			// Token: 0x040002DF RID: 735
			mouth,
			// Token: 0x040002E0 RID: 736
			feet,
			// Token: 0x040002E1 RID: 737
			hands
		}

		// Token: 0x020000A4 RID: 164
		[Flags]
		public enum Covers
		{
			// Token: 0x040002E3 RID: 739
			None = 0,
			// Token: 0x040002E4 RID: 740
			head = 16777216,
			// Token: 0x040002E5 RID: 741
			face = 1048576,
			// Token: 0x040002E6 RID: 742
			eyes = 131072,
			// Token: 0x040002E7 RID: 743
			lips = 65536,
			// Token: 0x040002E8 RID: 744
			mouthHole = 1024,
			// Token: 0x040002E9 RID: 745
			neck = 4194304,
			// Token: 0x040002EA RID: 746
			shoulders = 262144,
			// Token: 0x040002EB RID: 747
			arms = 256,
			// Token: 0x040002EC RID: 748
			forearms = 512,
			// Token: 0x040002ED RID: 749
			hands = 16384,
			// Token: 0x040002EE RID: 750
			torso = 2097152,
			// Token: 0x040002EF RID: 751
			back = 8388608,
			// Token: 0x040002F0 RID: 752
			breast = 1,
			// Token: 0x040002F1 RID: 753
			nipples = 2,
			// Token: 0x040002F2 RID: 754
			belly = 524288,
			// Token: 0x040002F3 RID: 755
			pubicArea = 32768,
			// Token: 0x040002F4 RID: 756
			buttocks = 16,
			// Token: 0x040002F5 RID: 757
			labia = 4,
			// Token: 0x040002F6 RID: 758
			vaginalHole = 8,
			// Token: 0x040002F7 RID: 759
			analHole = 32,
			// Token: 0x040002F8 RID: 760
			penis = 2048,
			// Token: 0x040002F9 RID: 761
			testicles = 4096,
			// Token: 0x040002FA RID: 762
			legs = 64,
			// Token: 0x040002FB RID: 763
			calf = 128,
			// Token: 0x040002FC RID: 764
			feet = 8192
		}

		// Token: 0x020000A5 RID: 165
		[Serializable]
		public class MaterialData
		{
			// Token: 0x040002FD RID: 765
			[Tooltip("the same index as the material in your renderer or your mesh.")]
			[JustToReadUI]
			public int materialIndex;

			// Token: 0x040002FE RID: 766
			[Tooltip("Drop the Material Maps that you created here. All materials that can be in this material index.")]
			public List<MaterialMap> materials;
		}

		// Token: 0x020000A6 RID: 166
		[Serializable]
		public class CustomScript
		{
			// Token: 0x040002FF RID: 767
			[AssemblyQualifiedName(implementingClass = typeof(Component), implementingInterface = typeof(ICustomClothingItemScript))]
			public string assemblyQualifiedName;
		}

		// Token: 0x020000A7 RID: 167
		[Serializable]
		public class CustomCollider
		{
			// Token: 0x04000300 RID: 768
			[Tooltip("Drop a renderer GameObject to be converted into a collider by the game here.")]
			public AssetReferenceGameObject address;

			// Token: 0x04000301 RID: 769
			[Tooltip("This collider can be animated, so... will this collider be animated using the avatar bones or your custom armature bones?")]
			public ClothingItemMap.CustomCollider.AnimationArmature animationArmature;

			// Token: 0x020000AF RID: 175
			public enum AnimationArmature
			{
				// Token: 0x0400030B RID: 779
				avatar,
				// Token: 0x0400030C RID: 780
				custom
			}
		}
	}
}
