using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.TValle.Tools.Runtime.Memory
{
	// Token: 0x02000039 RID: 57
	public interface IContextMemory
	{
		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000129 RID: 297
		string id { get; }

		// Token: 0x0600012A RID: 298
		void AddData(string id, string data, bool replace = true);

		// Token: 0x0600012B RID: 299
		string FindData(string id, string defaultValue);

		// Token: 0x0600012C RID: 300
		void AddData(string id, bool data, bool replace = true);

		// Token: 0x0600012D RID: 301
		bool FindDataBool(string id, bool defaultValue);

		// Token: 0x0600012E RID: 302
		void AddData(string id, int data, bool replace = true);

		// Token: 0x0600012F RID: 303
		int FindDataInt(string id, int defaultValue);

		// Token: 0x06000130 RID: 304
		void AddData(int id, int data, bool replace = true);

		// Token: 0x06000131 RID: 305
		int FindDataInt(int id, int defaultValue);

		// Token: 0x06000132 RID: 306
		bool TryFindDataInt(string id, out int value);

		// Token: 0x06000133 RID: 307
		bool TryFindDataInt(int id, out int value);

		// Token: 0x06000134 RID: 308
		void AddData(string id, float data, bool replace = true);

		// Token: 0x06000135 RID: 309
		void AddData(int id, float data, bool replace = true);

		// Token: 0x06000136 RID: 310
		float FindDataFloat(string id, float defaultValue);

		// Token: 0x06000137 RID: 311
		float FindDataFloat(int id, float defaultValue);

		// Token: 0x06000138 RID: 312
		bool TryFindDataFloat(int id, out float value);

		// Token: 0x06000139 RID: 313
		bool TryFindDataFloat(string id, out float value);

		// Token: 0x0600013A RID: 314
		void AddData<T>(string id, List<T> data, bool replace = true);

		// Token: 0x0600013B RID: 315
		bool TryFindDataArrayEmpty<T>(string id, out List<T> value);

		// Token: 0x0600013C RID: 316
		bool TryFindDataArrayNull<T>(string id, out List<T> value);

		// Token: 0x0600013D RID: 317
		void AddData<T>(string id, T[] data, bool replace = true);

		// Token: 0x0600013E RID: 318
		bool TryFindDataArrayEmpty<T>(string id, out T[] value);

		// Token: 0x0600013F RID: 319
		bool TryFindDataArrayNull<T>(string id, out T[] value);

		// Token: 0x06000140 RID: 320
		void AddData(string id, Texture2D data, bool replace = true);

		// Token: 0x06000141 RID: 321
		Texture2D FindDataImage(string id);

		// Token: 0x06000142 RID: 322
		bool TryFindDataImage(string id, ref Texture2D result);

		// Token: 0x06000143 RID: 323
		void AddDataObject<TKey, TValue>(TKey id, TValue data, bool replace = true);

		// Token: 0x06000144 RID: 324
		bool TryFindDataObject<TKey, TValue>(string id, out TKey key, out TValue value, TKey defaultKey, TValue defaultValue);

		// Token: 0x06000145 RID: 325
		void AddDataObject<T>(string id, T data, bool replace = true);

		// Token: 0x06000146 RID: 326
		bool TryFindDataObject<T>(string id, out T value, T defaultValue);

		// Token: 0x06000147 RID: 327
		bool TryFindDataObject<T>(string id, Type type, out T value, T defaultValue) where T : class;

		// Token: 0x06000148 RID: 328
		bool TryFindDataObject(string id, Type type, out object value, object defaultValue);

		// Token: 0x06000149 RID: 329
		bool RemoveData(string id);

		// Token: 0x0600014A RID: 330
		void Clear();
	}
}
