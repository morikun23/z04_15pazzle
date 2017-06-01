//担当：森田　勝
//概要：ピースを右にスライドさせるためのもの
//参考：なし

using UnityEngine;

namespace Z04.Logic {
	public class RightSlider : IPieceSlider {

		//初期位置
		private Vector2 _startPostion;
		//目的位置
		private Vector2 _destination;
		//どれだけスライドされているかの指標
		private int _t;
		//スライド指標の最大値
		private const int MAX = 10;

		/// <summary>
		/// 初期値
		/// </summary>
		/// <param name="arg_piece">移動させるピース</param>
		public void Initialize(Piece arg_piece) {
			_startPostion = arg_piece.ConvertPosition(arg_piece._status._id);
			_destination = arg_piece.ConvertPosition(arg_piece._status._id + 1);
			_t = 0;
		}

		/// <summary>
		/// 実際にスライドさせる
		/// </summary>
		/// <param name="arg_piece">スライドさせるピース</param>
		public void Slide(Piece arg_piece) {

			if (_t >= MAX) { return; }

			//移動量をフレームの分だけ分割させる
			Vector2 velocity = (_destination - _startPostion) / MAX;
			arg_piece._status._position += velocity;
			_t++;
		}

		/// <summary>
		/// 終了処理
		/// </summary>
		/// <param name="arg_piece">スライドさせたピース</param>
		public void Finalize(Piece arg_piece) {

		}

		/// <summary>
		/// スライド終了したかを調べる
		/// </summary>
		/// <returns>スライド終了の真偽</returns>
		public bool IsFinished() {
			return _t >= MAX;
		}
	}
}