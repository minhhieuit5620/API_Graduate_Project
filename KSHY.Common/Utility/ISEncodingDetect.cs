using System.Text;

namespace ISCommon.Utility
{
    public static class ISEncodingDetect
    {
        //     '****************************************************************************
        //' 機能名    : Module1.vb
        //' 機能説明  : 文字コード判定
        //' 備考      :
        //' 著作権    : Copyright(C) 2008 - 2009 のん All rights reserved
        //'           : このプログラムは、日本国著作権法および国際条約により保護
        //'           : されています。このプログラムを転載する場合は著作権所有者
        //'           : の許可が必要となります｡
        //' ---------------------------------------------------------------------------
        //' 使用条件  : このサイトの内容を使用(流用/改変/転載/等全て)した成果物を不特定
        //'           : 多数に公開/配布する場合は、このサイトを参考にした旨を記述してく
        //'           : ださい。(例)WEBページやReadMeにリンクを貼ってください
        //' ---------------------------------------------------------------------------
        //'****************************************************************************
        private const long JUDGEFIX = 9999;      //文字コード決定％
        private const long JUDGESIZEMAX = 1000;   //文字コード判定バイト数
        private const long SingleByteWeight = 1;  //１バイト　文字コードの一致重み
        private const int Multi_ByteWeight = 2;   //複数バイト文字コードの一致重み
                                                  //Private Enum JISMODE                'JISコードのモード
                                                  //    ctrl = 0                        '制御コード
                                                  //    asci = 1                        'ASCII
                                                  //    roma = 2                        'JISローマ字
                                                  //    kana = 3                        'JISカナ（半角カナ）
                                                  //    kanO = 4                        '旧JIS漢字 (1978)
                                                  //    kanN = 5                        '新JIS漢字 (1983/1990)
                                                  //    kanH = 6                        'JIS補助漢字
                                                  //End Enum

        //'----文字コード判定
        //' 関数名    : JudgeCode
        //' 返り値    : 判定結果文字コード名
        //' 引き数    : bytCode : 判定文字データ
        //' 機能説明  : 文字コードを判定する
        //' 備考      :
        public static System.Text.Encoding Detect(byte[] content)
        {
            //  string JudgeCode = "SJIS";
            System.Text.Encoding enc = Encoding.GetEncoding("SHIFT-JIS");
            long lngSJIS;
            //    Dim lngJIS As Long
            //    Dim lngEUC As Long
            //    Dim lngUNI As Long
            //    Dim lngUTF7 As Long
            //    Dim lngUTF8 As Long


            lngSJIS = Shift_JIS(content, true);
            if (lngSJIS >= JUDGEFIX) enc = Encoding.GetEncoding("SHIFT-JIS");

            return enc;
        }

        //'----SJIS関係
        //' 関数名    : JudgeSJIS
        //' 返り値    : 判定結果確率（％）
        //' 引き数    : bytCode : 判定文字データ
        //'           : fixFlag : 確定判断有無
        //' 機能説明  : SJISの文字コード判定(可能性)確率を計算する
        //' 備考      :
        private static long Shift_JIS(byte[] content, bool fixFlag = false)
        {
            long lngFit = 0, lngUB = 0;
            lngUB = JUDGESIZEMAX - 1;
            if (lngUB > content.Length)
                lngUB = content.Length;

            for (long i = 0; i < lngUB; i++)
            {
                //81-9F,E0-EF(1 byte)
                if ((content[i] >= 0x81 && content[i] <= 0x9F) || (content[i] >= 0xE0 && content[i] <= 0xEF))
                {
                    if (i <= content.Length - 1)
                    {
                        //40-7E,80-FC(2 byte)
                        if ((content[i + 1] >= 0x40 && content[i + 1] <= 0x7E) || (content[i + 1] >= 0x80 && content[i + 1] <= 0xFC))
                        {
                            lngFit = lngFit + (2 * Multi_ByteWeight);
                            i = i + 1;
                        }
                    }

                }
                //A1-DF(1 byte)
                else if (content[i] >= 0xA1 && content[i] <= 0xDF)
                    lngFit = lngFit + (1 * SingleByteWeight);

                //20-7E(1 byte)
                else if (content[i] >= 0x20 && content[i] <= 0x7E)
                    lngFit = lngFit + (1 * SingleByteWeight);

                //00-1F, 7F(1 byte)
                else if ((content[i] >= 0x00 && content[i] <= 0x1F) || content[i] == 0x7F)
                    lngFit = lngFit + (1 * SingleByteWeight);

            }

            return (lngFit * 100) / ((lngUB + 1) * (long)Multi_ByteWeight);
        }

    }
}
