//担当：森田　勝
//概要：盤面を管理するクラス
//参考：なし
using UnityEngine;

namespace Z04.Logic {
	public class SquareManager {

		//盤面を表現した２次配列
		private int[,] _squares;
		
		public void Initialize() {
			//TODO:拡張性の向上

			//1:配置済み　0:配置なし
			_squares = new int[Config.SQUARE.ROW , Config.SQUARE.COLUMN]{
				{1,1,1,1},
				{1,1,1,1},
				{1,1,1,1},
				{1,1,1,0}
			};
		}

		/// <summary>
		/// アップデート
		/// </summary>
		public void UpdateByFrame() {
			
		}

		/// <summary>
		/// 指定されたマスが空の状態かを調べる
		/// </summary>
		/// <param name="arg_row">列</param>
		/// <param name="arg_column">行</param>
		/// <returns></returns>
		public bool IsEmpty(int arg_row,int arg_column) {
			//空（から）
			const int EMPTY = 0;
			//配列の可能範囲を超えたら中断
			if (arg_row < 0 || Config.SQUARE.ROW <= arg_row) return false;
			if (arg_column < 0 || Config.SQUARE.COLUMN <= arg_column) return false;

			return _squares[arg_column , arg_row] == EMPTY;
		}

		/// <summary>
		/// マスが移動したときに、盤面を更新する
		/// </summary>
		/// <param name="arg_id">新しいマスID</param>
		/// <param name="arg_row">以前の列</param>
		/// <param name="arg_column">以前の行</param>
		public void Swapped(int arg_id,int arg_row,int arg_column) {
			_squares[arg_id / Config.SQUARE.COLUMN , arg_id % Config.SQUARE.ROW] = 1;
			_squares[arg_column , arg_row] = 0;
		}
	}
}