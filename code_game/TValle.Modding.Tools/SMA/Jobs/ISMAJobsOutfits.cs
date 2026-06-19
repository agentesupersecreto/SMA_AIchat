using System;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Moddding.Clothing.Maps;

namespace Assets.TValle.Tools.Runtime.SMA.Jobs
{
	// Token: 0x0200001B RID: 27
	public interface ISMAJobsOutfits
	{
		// Token: 0x060000BB RID: 187
		int CountOfClothingPiecesCoveringBodyPartOfMainPlayer(SensitiveBodyPart bodyPart);

		// Token: 0x060000BC RID: 188
		int CountOfClothingPiecesCoveringBodyPartOfMainNonPlayer(SensitiveBodyPart bodyPart);

		// Token: 0x060000BD RID: 189
		ClothingItemMap.Type GetFirstOrDefaultClothingPiecesCoveringTypeOfMainNonPlayer(SensitiveBodyPart bodyPart);
	}
}
