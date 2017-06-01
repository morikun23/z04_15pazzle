//担当者：森田　勝
//概要　：ユーザー自身が操作をするためのクラス
//参考　：2Dマウス入力「http://qiita.com/yxuyxu/items/ffec547e9b93cfd2b99d」

using UnityEngine;

namespace Z04 {
	public class Player : IPlayable {

		//スライドした回数(最終結果に影響)
		public int _slideCount { get; private set; }

		/// <summary>
		/// 初期化
		/// </summary>
		public void Initialize() {
			_slideCount = 0;
		}

		/// <summary>
		/// アップデート
		/// </summary>
		public void UpdateByFrame() {
			if (Input.GetMouseButtonDown(0)) {
				Vector2 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				if (Physics2D.OverlapPoint(clickPos)) {
					RaycastHit2D hitInfo = Physics2D.Raycast(clickPos , -Vector2.up);
					if (hitInfo) {
						//対象を選択
						hitInfo.transform.GetComponent<View.Piece>().OnClicked();
						this.AddSlideCount();
					}
				}
			}
		}

		/// <summary>
		/// スライド回数を増やす
		/// </summary>
		private void AddSlideCount() {
			_slideCount++;
		}
	}
}