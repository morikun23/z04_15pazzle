//担当：森田　勝
//概要：ピース全体の描画を担当する
//　　　個々のピースがお互いに干渉しあうときにこれを間にはさむ
//参考：なし

using System.Collections.Generic;
using UnityEngine;

namespace Z04.View {
	public class PieceManager : MonoBehaviour {

		//自身のロジック
		Logic.PieceManager _logic;
		//ピースが格納されるリスト
		List<Piece> _pieces;

		//使用するスプライトの名前(※一貫した名前を使用させること)
		private const string _spriteName = "SP_Pazzle_";

		/// <summary>
		/// 初期化
		/// </summary>
		/// <param name="arg_logic">ロジック</param>
		public void Initialize(Logic.PieceManager arg_logic) {

			_logic = arg_logic;
			_pieces = new List<Piece>();

			for (int i = 0; i < Config.SQUARE.COUNT - 1; i++) {
				//TODO : ResourceManagerを使用する
				GameObject prefab = Resources.Load<GameObject>("PB_PieceBase");
				Piece piece = Instantiate(prefab).GetComponent<Piece>();
				piece.Initialize(_logic._pieces[i]);
				piece.SetSprite(ResourceManager.Instance.GetSprite(_spriteName + i));

				//リストに追加
				_pieces.Add(piece);
			}
		}

		/// <summary>
		/// アップデート
		/// </summary>
		public void UpdateByFrame() {
			foreach (Piece piece in _pieces) {
				piece.UpdateByFrame();
			}
		}
	}
}