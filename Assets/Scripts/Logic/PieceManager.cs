//担当：森田　勝
//概要：ロジック用のピースを管理するクラス
//　　　お互いが干渉しあうときに間にはさむ

using System.Collections.Generic;

namespace Z04.Logic {
	public class PieceManager {
		
		//ピースが格納されるリスト
		public List<Piece> _pieces { get; private set; }

		private SquareManager _squareManager { get; set; }

		public void Initialize() {
		
			_squareManager = GameManager.Instance._logicManager._squareManager;

			_pieces = new List<Piece>();
				
			for (int i = 0; i < Config.SQUARE.COUNT - 1; i++) {
				Piece piece = new Piece();
				piece.Initialize(i);
				//リストに追加
				_pieces.Add(piece);
			}
		}

		public void UpdateByFrame() {
			foreach (Piece piece in _pieces) {
				switch (piece._state) {
					case Piece.State.IDLING: break;

					case Piece.State.WAITING_FOR_SLIDE:
					//可能であればスライドを開始する
					SlideIfPossible(piece);
					break;

					case Piece.State.SLIDING: break;
				}
				piece.UpdateByFrame();
			}
		}

		public void SlideIfPossible(Piece arg_piece) {
			//ピースのマス番号
			int id = arg_piece._status._id;
			//ピースの列番号
			int row = id % Config.SQUARE.ROW;
			//ピースの行番号
			int column = id / Config.SQUARE.COLUMN;

			//TODO:クラス化
			//左方向のチェック
			if (_squareManager.IsEmpty(row - 1 , column)) {
				arg_piece.Slide(new LeftSlider());
				arg_piece._status._id = id - 1;
				_squareManager.Swapped(arg_piece._status._id , row , column);
				return;
			}
			//右方向のチェック
			if (_squareManager.IsEmpty(row + 1 , column)) {
				arg_piece.Slide(new RightSlider());
				arg_piece._status._id = id + 1;
				_squareManager.Swapped(arg_piece._status._id , row , column);
				return;
			}
			//上方向のチェック
			if (_squareManager.IsEmpty(row , column - 1)) {
				arg_piece.Slide(new UpSlider());
				arg_piece._status._id = id - Config.SQUARE.COLUMN;
				_squareManager.Swapped(arg_piece._status._id , row , column);
				return;
			}
			//下方向のチェック
			if (_squareManager.IsEmpty(row , column + 1)) {
				arg_piece.Slide(new DownSlider());
				arg_piece._status._id = id + Config.SQUARE.COLUMN;
				_squareManager.Swapped(arg_piece._status._id , row , column);
				return;
			}
			//４方向ともスライドできない場合は、スライドをキャンセルする
			arg_piece.Cancel();
		}
	}
}