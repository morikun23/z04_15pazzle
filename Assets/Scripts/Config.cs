//担当：森田　勝
//概要：ゲームの設定を管理するクラス
//　　　なるべく定数として所持したい
//参考：なし

namespace Z04 {
	public class Config {

		//FPS
		public const int FPS = 60;

		/// <summary>
		/// 盤面に関する設定
		/// </summary>
		public struct SQUARE {
			//マスの数
			public const int COUNT = 16;
			//列の数
			public const int ROW = 4;
			//行の数
			public const int COLUMN = 4;
		}

		/// <summary>
		/// 難易度に関する設定
		/// </summary>
		public class Level {

		}
		
	}
}