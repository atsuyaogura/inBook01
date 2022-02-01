# inBook01 : See you in Books!

<p align="center">
  <img src="./Assets/ReadmeImages/ForReadme.jpg" width="738">
</p>

## 作品の動機　/ Motivation of This Project

「本の中に入れたら」、そんな事を思ってこのプロジェクト：inBookを始めた。
場所は違えども、同じ時刻に、同じ本を読んでいる人達が、同じ空間に集まれたら。
そこでは、何が起こるだろうか？
本の中で出会い、本の中で感想を伝えあい、本の中で討論しあい、本の中で教えあい、本の中で仲良くなり、本の中で～～～
本の中で、何が始まるだろうか？
近い、未来の本の読み方、在り方を、想像してみた。

([動画のリンク / Video Link](https://youtu.be/R1LSrxXduy0))

## How It Works
1.	前もって青空文庫で人気な本の情報を500冊スクレイピング。Excel fileにまとめる。
2.	Home Sceneのスタート関数で1のExcel fileをもとに本500冊を作成。
3.	2で作成した本から、本を選び、選んだ本のURLを取得
4.	Book Sceneのスタート関数で3の選んだ本のURLから本文をUnityWebrequestで取得、それを元にページ作成

Photonを使用し、HomeSceneではロビーを用いたマッチメイキング、BookSceneではボイスチャットをできるようにした。
（[こちらの講義](https://www.udemy.com/course/multiplayer-virtual-reality-vr-development-with-unity/)を大いに参考とした。/ I learned a lot from [this Lecture.](https://www.udemy.com/course/multiplayer-virtual-reality-vr-development-with-unity/)）

## 自分のことについて
横浜国立大学　建築学科　3年
Unity, C# ともに５か月前にOculus Quest 2を買った際に始めました。
建築学科生として物質世界の空間・環境設計に興味がありますが、最近はそれにもましてVRのワールド？環境？設計に魅せられています。
物質的な世界、電子的な世界、分け隔てなく、楽しい空間、環境を作りたいです。
