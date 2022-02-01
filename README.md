# inBook01 : See you in Books!
([動画のリンク / Video Link](https://youtu.be/R1LSrxXduy0))

<p align="center">
  <img src="./Assets/ReadmeImages/ForReadme.jpg" width="738">
</p>

## 作品の動機　/ Motivation of This Project

（日本語）

本の中が新しいコミュニティの場になると思った。

inBookを通じて、場所は違えど、同じ時刻に、同じ本を読んでいる人達が、同じ空間に集まることができる。

そこで、何が起こるか想像した。

本の中で知り合い、本の中で感想を伝えあい、本の中で討論しあい、本の中で教えあい、本の中で仲良くなり、本の中で～～～ 

本の中に入れたら、何が起きるだろう？

(English)

The inside of the book would be a new place for communities if we can enter books.

When we use inBook, overcoming the difference of place, we can gather in a same place with others reading the same book at the same time.

What happens there?

In books will we encounter someone, share each thought on the book, discuss the book, teach each other and become friends and ...

What if we can enter books?

([動画のリンク / Video Link](https://youtu.be/R1LSrxXduy0))

## 実装したこと / How It Works
（日本語）
1.	前もって青空文庫で人気な本の情報を500冊スクレイピング。[csv file](./Assets/Resouces/CSV/bookURLtest.csv)にまとめる。
2.	Home Sceneのスタート関数で1のExcel fileをもとに本500冊を作成。
3.	2で作成した本から、プレイヤーは本を選び、Unityはプレイヤーが選んだ本のURLを取得
4.	Book Sceneのスタート関数で、選んだ本のURLから本文をUnityWebrequestで取得、それを元にページ作成

(English)
1. Aside from this unity project, I scraped information about 500 popular Aozora books and save it as [csv file](./Assets/Resouces/CSV/bookURLtest.csv).
2. Start function in the "HomeScene" makes 500 books accoding to the 1's csv file.
3. Player chooses his favorite book, and Unity get the books URL.
4. Start function in the "BookScene" gets book's text, using UnityWebrequest, and instantiates pages.


Photonを使用し、HomeSceneではロビーを用いたマッチメイキング、BookSceneではボイスチャットをできるようにした。
（[こちらの講義](https://www.udemy.com/course/multiplayer-virtual-reality-vr-development-with-unity/)を大いに参考とした。/ I learned a lot from [this Lecture.](https://www.udemy.com/course/multiplayer-virtual-reality-vr-development-with-unity/)）

## 自分のことについて
横浜国立大学　建築学科　3年
Unity, C# ともに５か月前にOculus Quest 2を買った際に始めました。
建築学科生として物質世界の空間・環境設計に興味がありますが、最近はそれにもましてVRのワールド？環境？設計に魅せられています。
物質的な世界、電子的な世界、分け隔てなく、楽しい空間、環境を作りたいです。
