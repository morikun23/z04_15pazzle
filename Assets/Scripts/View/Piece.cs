//担当：森田　勝
//概要：パズルのピースの描画を担当するクラス
//参考：なし

using UnityEngine;

namespace Z04.View {
	public class Piece : MonoBehaviour {
		
		//スプライトを描画するためのコンポーネント
		private SpriteRenderer _spriteRenderer;

		//自身のLogic部分
		private Logic.Piece _logic;

		/// <summary>
		/// 初期化
		/// </summary>
		/// <param name="arg_logic">ロジック</param>
		public void Initialize(Logic.Piece arg_logic) {
			_logic = arg_logic;
			_spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		}

		/// <summary>
		/// アップデート
		/// </summary>
		public void UpdateByFrame() {
			this.Convert();
		}

		/// <summary>
		/// 描画するスプライトを設定する
		/// </summary>
		/// <param name="arg_sprite">使用するスプライト</param>
		public void SetSprite(Sprite arg_sprite) {
			_spriteRenderer.sprite = arg_sprite;
		}

		/// <summary>
		/// 描画するための座標に補正をする
		/// </summary>
		private void Convert() {
			this.transform.position = _logic._status._position;
			this.transform.transform.localScale = Vector3.one * _logic._status._scale;
		}

		/// <summary>
		/// UIから入力を受け付けたときに呼ばれる
		/// </summary>
		public void OnClicked() {
			_logic._state = Logic.Piece.State.WAITING_FOR_SLIDE;
		}

	}
}