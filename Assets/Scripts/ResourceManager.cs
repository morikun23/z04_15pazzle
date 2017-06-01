//担当：森田　勝
//概要：リソース関係のファイルを管理するクラス
//　　　一括管理にすることで、解放漏れなどのリスクを回避させる
//　　　ここからスプライトやプレハブなど細分化したい
//参考：なし

using System.Collections.Generic;
using UnityEngine;

namespace Z04 {
	public class ResourceManager {

		#region Singleton設計
		private static ResourceManager _instance;
		
		public static ResourceManager Instance {
			get {
				if(_instance == null) {
					_instance = new ResourceManager();
					Debug.Log("created");
				}
				return _instance;
			}
		}

		private ResourceManager() { }
		#endregion
		
		private Dictionary<string , Sprite> _sprites;

		/// <summary>
		/// 初期化
		/// </summary>
		public void Initialize() {
			//Multipleなスプライトを取り出す
			_sprites = new Dictionary<string , Sprite>();

			string spritePass = "SP_Pazzle";
			
			Sprite[] _base = Resources.LoadAll<Sprite>(spritePass);
			for (int i = 0; i < _base.Length; i++) {

				string spriteName = spritePass + '_' + i;
				
				_sprites.Add(spriteName ,
					System.Array.Find(_base , _ => _.name.Equals(spriteName)));
				
			}
		}
		
		/// <summary>
		/// スプライトを取得する
		/// </summary>
		/// <param name="arg_name">ファイル名</param>
		/// <returns>スプライトファイル</returns>
		public Sprite GetSprite(string arg_name) {
			return _sprites[arg_name];
		}
		
	}
}