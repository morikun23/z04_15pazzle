//担当：森田　勝
//概要：ピースのスライドする動きを抽象化したインターフェイス
//　　　それぞれの方向で処理が異なる箇所があるので、
//　　　Strategyパターンを用いた設計にしています。
//参考：なし

namespace Z04.Logic {
	public interface IPieceSlider {

		//初期化
		void Initialize(Piece arg_piece);
		//スライドの更新
		void Slide(Piece arg_piece);
		//終了処理
		void Finalize(Piece arg_piece);
		//終了したかを調べる
		bool IsFinished();
	}
}