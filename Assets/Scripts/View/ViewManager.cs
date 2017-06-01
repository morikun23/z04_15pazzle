//担当：森田　勝
//概要：View担当のクラスを管理する
//参考：なし

using UnityEngine;

namespace Z04.View {
	public class ViewManager : MonoBehaviour {

		public PieceManager _pieceManager { get; private set; }

		private Logic.LogicManager _logic;

		/// <summary>
		/// 初期化
		/// </summary>
		/// <param name="arg_logic">LogicManager</param>
		public void Initialize(Logic.LogicManager arg_logic) {
			_logic = arg_logic;
			_pieceManager = new PieceManager();
			_pieceManager.Initialize(_logic._pieceManager);
		}

		/// <summary>
		/// アップデート
		/// </summary>
		public void UpdateByFrame() {
			_pieceManager.UpdateByFrame();
		}
	}
}