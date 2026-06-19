using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.ChatMapper
{
	// Token: 0x02000207 RID: 519
	[Serializable]
	public class Assets
	{
		// Token: 0x04000D57 RID: 3415
		[XmlArrayItem("Actor")]
		[XmlArray("Actors")]
		public List<Actor> Actors = new List<Actor>();

		// Token: 0x04000D58 RID: 3416
		[XmlArrayItem("Item")]
		[XmlArray("Items")]
		public List<Item> Items = new List<Item>();

		// Token: 0x04000D59 RID: 3417
		[XmlArrayItem("Location")]
		[XmlArray("Locations")]
		public List<Location> Locations = new List<Location>();

		// Token: 0x04000D5A RID: 3418
		[XmlArrayItem("Conversation")]
		[XmlArray("Conversations")]
		public List<Conversation> Conversations = new List<Conversation>();

		// Token: 0x04000D5B RID: 3419
		[XmlArrayItem("UserVariable")]
		[XmlArray("UserVariables")]
		public List<UserVariable> UserVariables = new List<UserVariable>();
	}
}
