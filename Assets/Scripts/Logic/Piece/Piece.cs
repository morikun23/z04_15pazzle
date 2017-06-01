//担当：森田　勝
//概要：パズルのピースのロジックを担当
//参考：なし

using UnityEngine;

namespace Z04.Logic {
	public class Piece {

		//TODO:クラス化
		public enum State {
			//静止中
			IDLING,
			//スライド待機中
			WAITING_FOR_SLIDE,
			//スライド中
			SLIDING
		}
		
		/// <summary>
		/// ピースの基本情報
		/// </summary>
		public class Status {
			//マス番号
			public int _id;
			public Vector2 _position;
			public float _scale;
		}

		//現在の状態
		public State _state { get; set; }
		//ピースの情報
		public Status _status { get; private set; }
		//スライド用インスタンス
		private IPieceSlider _slider { get; set; }

		/// <summary>
		/// 初期化
		/// </summary>
		/// <param name="arg_id">初期マス番号</param>
		public void Initialize(int arg_id) {
			_status = new Status() {
				_scale = 2.0f,
				_id = arg_id
			};
			_status._position = ConvertPosition(_status._id);
			_state = State.IDLING;
			_slider = null;
		}

		/// <summary>
		/// アップデート
		/// </summary>
		public void UpdateByFrame() {
			switch (_state) {
				case State.IDLING: break;
				case State.WAITING_FOR_SLIDE: break;
				case State.SLIDING:
				if (_slider.IsFinished()) {
					_slider.Finalize(this);
					break;
				}
				_slider.Slide(this); break;
			}
		}

		/// <summary>
		/// スライドを開始させる
		/// </summary>
		/// <param name="arg_slider">使用するスライダー</param>
		public void Slide(IPieceSlider arg_slider) {
			_slider = arg_slider;
			_state = State.SLIDING;
			_slider.Initialize(this);
		}

		/// <summary>
		/// マス番号に適応した座標を取得する
		/// </summary>
		/// <param name="arg_id">マス番号</param>
		/// <returns>指定されたマス番号の座標</returns>
		public Vector2 ConvertPosition(int arg_id){
			Vector2 pos = new Vector2() {
				x = arg_id % Config.SQUARE.ROW * _status._scale,
				y = -arg_id / Config.SQUARE.COLUMN * _status._scale
			};
			pos.x -= _status._scale * 1.5f;
			pos.y += _status._scale * 1.5f;
			return pos;
		}

		/// <summary>
		/// スライド状態を中止させる
		/// </summary>
		public void Cancel() {
			_state = State.IDLING;
			_slider = null;
		}
	}
}