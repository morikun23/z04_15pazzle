//担当：森田　勝
//概要：MVCのLogic部分を担当するクラスを管理する
//参考：なし

namespace Z04.Logic {
	public class LogicManager {

		public PieceManager _pieceManager { get; private set; }
		public SquareManager _squareManager { get; private set; }

		/// <summary>
		/// 初期化
		/// </summary>
		public void Initialize() {
			_squareManager = new SquareManager();
			_pieceManager = new PieceManager();

			_squareManager.Initialize();
			_pieceManager.Initialize();
		}

		/// <summary>
		/// アップデート
		/// </summary>
		public void UpdateByFrame() {
			_squareManager.UpdateByFrame();
			_pieceManager.UpdateByFrame();
		}
	}
}