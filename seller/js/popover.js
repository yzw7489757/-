{ 
  "ProductName":{
  	"Type":"String",
  	"Description":"使用以下模板构建产品名称：主品牌 + 子品牌、系列或产品名称 + 最多 3 个关键属性 + 通用产品类型。产品名称必须清楚准确，且应能描述要销售的产品。此模板有助于顾客记住你的产品。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：Men's Dress Casual Shirt Navy</li>  <li>可接受：Women's Solid Color Black Dress Pants</li>  <li>不能接受：Best Price!!! **CHEAP** Baby Stroller!!!</li>  </ul>"
  },
  "Description":{
  	"Type":"String",
  	"Description":"一份关于您产品的详细描述。限 4,000 个字符，且仅前 250 个字符显示在初始获取页上。切勿包含任何 HTML 代码，有关店铺政策的详细信息，其它店铺特定的语言或多行信息。“换行”字符（如“enter”或“return”）将导致您的文件出现问题。有关大小，合身度，以及尺寸的信息都对服装类产品很有帮助。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：This dress shirt is 100% cotton and fits true to size.</li>  <li>不能接受：This &lt;b&gt;dress shirt&lt;/b&gt; is 100% cotton and &lt;i&gt;fits true to size&lt;/i&gt;.</li>  </ul>"
  },
  "Tags":{
  	"Type":"String",
  	"Description":"分配给源文件中每个产品的非层次结构关键字或关键词。此类元数据有助于描述商品和进行分类，且方便于在 Wish.com 上浏览或搜索时再次找到。标签应用逗号分隔，但不能在各个标签中使用逗号。添加的标签越多，标签的准确性越高，用户找到您的产品的机率越高。每个产品最多 10 个标签，如果添加的标签超过 10 个，我们将忽略多余的标签。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：Shirt, Men's Fashion, Navy, Blue, Casual, Apparel</li>  <li>可接受：Women's Fashion, Jewelry &amp; Watches</li>  <li>可接受：Men's Fashion, Suits, Mafia, Silk Tie, Ties</li>  <li>不能接受：Clearance Items</li>  <li>不能接受：Cheap Cheap Cheap</li>  <li>不能接受（标签太多）：Fashion, Suits, Ties, Silk Ties, Men's Suits, Italian Made Suits, Italian, Men's Fashion, Hand Crafted, Silk, High Quality</li>  </ul>"
  },
  "UniqueId":{
  	"Type":"String",
  	"Description":"请提供您在内部使用以标识此商品的唯一 SKU 号。请保留此 SKU 号，以便将来获取此商品的任何 SKU 号码更新。Wish.com 的系统使用 SKU 号识别、跟踪、更新和报告此商品。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：HSC0424PP</li>  <li>可接受：112123343455432</li>  <li>不能接受：2</li>  <li>不能接受：a</li>  </ul>"
  },
  "Price":{
  	"Type":"Price",
  	"Description":"将在 Wish.com 上显示的产品价格，不包含其它文字。这是用户为产品支付的金额。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：$100.99</li>  <li>可接受：10.99</li>  <li>不能接受：$49.99 + S/H</li></ul>"
  },
  "Quantity":{
  	"Type":"Integer",
  	"Description":"此SKU的库存量。请使用保险库存来作为Wish指定的库存。最大值为50万。超过此值的库存量将会自动降低。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：1200</li>  <li>可接受：0</li>  <li>可接受：4</li>  <li>不能接受：In stock</li>  <li>不能接受：Out of Stock</li>  </ul>"
  },
  "Shipping":{
  	"Type":"Price",
  	"Description":"每个产品的预计陆运费用。这是用户将为每个产品销售订单支付的运费。不得包含任何其它文字。",
  	"Examples":"<ul class\"example-list\">  <li>可接受：$4.00</li>  <li>可接受：4.99</li>  <li>不能接受：$4.99 + S/H</li>  </ul>"
  },
  "DeclaredName":{
  	"Type":"String",
  	"Description":"申报物流名称。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：Repair Tools Kit Set</li>  <li>可接受：Rings</li>  <li>不能接受：!Rings</li>  <li>不能接受：T</li>  <li>不能接受：Good 衬衫</li>  </ul>"
  },
  "DeclaredLocalName":{
  	"Type":"String",
  	"Description":"以原产国的当地语言申报名称。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：棉质外套</li>  <li>不能接受：!棉质外套</li>  <li>不能接受：棉</li>  </ul>"
  },
  "PiecesIncluded":{
  	"Type":"Integer",
  	"Description":"与此产品关联的件数。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：2</li>  <li>可接受：1</li>  <li>不能接受：-1</li>  </ul>"
  },
  "PackageLength":{
  	"Type":"Decimal",
  	"Description":"您将打包发给用户的产品的长度（单位：厘米）。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：10</li>  </ul>"
  },
  "PackageWidth":{
  	"Type":"Decimal",
  	"Description":"您将打包发给用户的产品的宽度（单位：厘米）。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：13.40</li></ul>"
  },
  "PackageHeight":{
  	"Type":"Decimal",
  	"Description":"您将打包发给用户的产品的高度（单位：厘米）。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：13.40</li></ul>"
  },
  "PackageWeight":{
  	"Type":"Decimal",
  	"Description":"您将打包发给用户的产品的重量。（单位：克）。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：151.5</li>  <li>可接受：10</li>  </ul>"
  },
  "CountryOfOrigin":{
  	"Type":"String",
  	"Description":"产品生产国。国家代码需遵循ISO 3166 Alpha-2代码规则。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：CN</li>  <li>可接受：US</li>  <li>不能接受：China</li>  </ul>"
  },
  "CustomHSCode":{
  	"Type":"String",
  	"Description":"用于海关申报的协调关税制度。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：33021010.00</li>  <li>可接受：6403.20</li>  <li>不能接受：2</li>  <li>不能接受：a</li>  </ul>"
  },
  "CustomDeclaredValue":{
  	"Type":"Price",
  	"Description":"将会向海关申报的您产品的货值。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：$100.99</li>  <li>可接受：10.99</li>  <li>不能接受：$49.99 + S/H</li>  </ul>"
  },
  "ContainsPowder":{
  	"Type":"Boolean",
  	"Description":"产品是否包含粉末？",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：Yes</li>  <li>可接受：No</li>  <li>不能接受：0</li>  </ul>"
  },
  "ContainsLiquid":{
  	"Type":"Boolean",
  	"Description":"产品是否包含液体？",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：Yes</li>  <li>可接受：No</li>  <li>不能接受：0</li>  </ul>"
  },
  "ContainsBattery":{
  	"Type":"Boolean",
  	"Description":"产品是否带电池？",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：Yes</li>  <li>可接受：No</li>  <li>不能接受：0</li>  </ul>"
  },
   "ContainsMetal":{
  	"Type":"Boolean",
  	"Description":"产品是否含有金属？",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：Yes</li>  <li>可接受：No</li>  <li>不能接受：0</li>  </ul>"
  },
  "Men'sApparel":{
  	"Type":"",
  	"Description":"",
  	"Examples":"",
  	"images":"./images/mens_sizing_diagram_600px.png"
  },
   "Women'sApparel":{
  	"Type":"",
  	"Description":"",
  	"Examples":"",
  	"images":"./images/womens_sizing_diagram_600px.png"
  },
  "Men'sSuitandTuxedos":{
  	"Type":"",
  	"Description":"",
  	"Examples":"",
  	"images":"./images/mens_sizing_diagram_600px.png"
  },
  "GoodsCode":{
  	"Type":"String",
  	"Description":"Goods Code必须包含在用户的产品库中。",
  	"Examples":""
  },
  "MainImageURL":{
  	"Type":"URL",
  	"Description":"产品照片的 URL。直接链接到图片，而不是它所在的页面。我们接受 JPEG、PNG 或 GIF 格式。 切勿包含公司徽标、名称、推销或其它标识性文字。图片的像素至少为 100 x 100 像素。不要包含任何“图片找不到”的图片。我们不接受以 https:// 开头的图片 URL。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：http://www.yourwebsite.com/images/7324204/3</li>  <li>可接受：http://www.yourwebsite.com/images/dress.jpg</li>  <li>不能接受：https://www.your website.com/images/7324204/3</li>  <li>不能接受：http://www.yourwebsite.com/images/dresses.html</li>  </ul>"
  },
  "ShippingTime":{
  	"Type":"String",
  	"Description":"将产品送到买家手中所耗费的时间。请将发货和送货所需的时间计算在内。提供时间范围（天数）。下限不得少于 2 天。请将发货和送货所需的时间计算在内。提供时间范围（天数）。下限不得少于 2 天。最长配送时间必须比最小配送时间至少多5天。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：20-30</li>  <li>可接受：15-26</li>  <li>不能接受：1-2</li>  <li>不能接受：0</li>  <li>不能接受：7-7</li>  </ul>"
  },
  "ParentUniqueId":{
  	"Type":"String",
  	"Description":"定义产品变量时，我们必须知道要将变量添加哪个产品。“父唯一 ID”是您要添加此变量的产品的“唯一 ID”。\"父唯一 ID\"必须已经存在于 Wish 上，或包含在上传位置中。\"父唯一 ID”也被称为“父SKU”。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：HSC0424PP</li>  <li>可接受：112123343455432</li>  <li>不能接受：2</li>  <li>不能接受：a</li>  </ul>"
  },
  "Size":{
  	"Type":"String",
  	"Description":"产品尺码（尤其是服装、鞋类或首饰类产品）每个尺码变量必须在CSV文件中设置独立的行，并填写对应的唯一的SKU编号及库存数量。该变量必须是数字或在<a href=\"Documentation.html?target=Size\" target=\"_blank\">目前被接受的尺码表</a>内。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：S</li>  <li>可接受：XXL</li>  <li>可接受：6</li>  <li>可接受：6.5</li>  <li>不能接受：small</li>  <li>不能接受：S, M</li>  </ul>"
  },
  "Color":{
  	"Type":"String",
  	"Description":"产品的颜色，特别是涉及服装或者珠宝首饰。每一种颜色变量在CSV文件中必须有对应的行，并且需要有独立的SKU编号以及库存数量。如果您喜欢表现两种颜色（比如：黑色和红色），您可以通过“&”符号轻松的将颜色分开（比如：black & red）注意：请勿将其与产品含有两种颜色变量混淆在一起请务必确定您所输入的颜色名称已经包含在<a href=\"Documentation.html?target=Color\" target=\"_blank\">Wish可接受的颜色列表</a>内。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：red</li>  <li>可接受：black &amp; blue</li>  <li>不能接受：red, blue</li>  <li>不能接受：black &amp; blue &amp; green</li>  </ul>"
  },
  "MSRP":{
  	"Type":"Price",
  	"Description":"制造商的建议零售价。建议填写此字段，因为它将在 Wish 的产品销售价格上方显示为带删除线的价格。该字段不得包含其它文字。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：$19.00</li>  <li>可接受：19.99</li>  <li>不能接受：19.99 + S/H</li>  </ul>"
  },
  "Brand":{
  	"Type":"String",
  	"Description":"产品的品牌或制造商。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：Nike</li>  <li>可接受：Sony</li>  </ul>"
  },
  "LandingPageURL":{
  	"Type":"URL",
  	"Description":"网站上包含适用产品的产品详细信息和购买按钮的 URL。如果适用，请在跳转 URL 的末尾附加分析跟踪代码。我们不接受以 https:// 开头的 URL。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：http://www.amazon.com/gp/product/B008PE00DA/ref=s9_simh_gw_p193_d0_i3?ref=wish</li>  <li>不能接受：https://www.wish.com/c/509e9ebeb23b1e5240d253</li>  </ul>"
  },
  "ExtraImageURL":{
  	"Type":"URL",
  	"Description":"产品照片的 URL。直接链接到图片，而不是它所在的页面。与图片 URL（默认图片）相同的规则适用。您可以指定一个或多个其它用字符“|”分隔的图片。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：http://www.yourwebsite.com/images/7324204/3</li>  <li>可接受：http://www.yourwebsite.com/images/dress.jpg</li>  <li>不能接受：https://www.your website.com/images/7324204/3</li>  <li>不能接受：http://www.yourwebsite.com/images/dresses.html</li>  </ul>"
  },
  "UPC":{
  	"Type":"String",
  	"Description":"12 位数字的通用产品代码 (UPC) — 不包含字母或其它字符，是用于跟踪店内商品和销售时扫描产品的条形码符号。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：716393133224</li>  <li>不能接受：asdf884445ds</li>  </ul>"
  },
  "ExtraImageURL1":{
  	"Type":"URL",
  	"Description":"产品照片的 URL。直接链接到图片，而不是它所在的页面。与主图片 URL（默认图片）相同的规则适用。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：http://www.yourwebsite.com/images/7324204/3</li>  <li>可接受：http://www.yourwebsite.com/images/dress.jpg</li>  <li>不能接受：https://www.your website.com/images/7324204/3</li>  <li>不能接受：http://www.yourwebsite.com/images/dresses.html</li>  </ul>"
  },
  "ExtraImageURL2":{
  	"Type":"URL",
  	"Description":"产品照片的 URL。直接链接到图片，而不是它所在的页面。与主图片 URL（默认图片）相同的规则适用。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：http://www.yourwebsite.com/images/7324204/3</li>  <li>可接受：http://www.yourwebsite.com/images/dress.jpg</li>  <li>不能接受：https://www.your website.com/images/7324204/3</li>  <li>不能接受：http://www.yourwebsite.com/images/dresses.html</li>  </ul>"
  },
  "ExtraImageURL3":{
  	"Type":"URL",
  	"Description":"产品照片的 URL。直接链接到图片，而不是它所在的页面。与主图片 URL（默认图片）相同的规则适用。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：http://www.yourwebsite.com/images/7324204/3</li>  <li>可接受：http://www.yourwebsite.com/images/dress.jpg</li>  <li>不能接受：https://www.your website.com/images/7324204/3</li>  <li>不能接受：http://www.yourwebsite.com/images/dresses.html</li>  </ul>"
  },
  "ExtraImageURL4":{
  	"Type":"URL",
  	"Description":"产品照片的 URL。直接链接到图片，而不是它所在的页面。与主图片 URL（默认图片）相同的规则适用。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：http://www.yourwebsite.com/images/7324204/3</li>  <li>可接受：http://www.yourwebsite.com/images/dress.jpg</li>  <li>不能接受：https://www.your website.com/images/7324204/3</li>  <li>不能接受：http://www.yourwebsite.com/images/dresses.html</li>  </ul>"
  },
  "ExtraImageURL5":{
  	"Type":"URL",
  	"Description":"产品照片的 URL。直接链接到图片，而不是它所在的页面。与主图片 URL（默认图片）相同的规则适用。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：http://www.yourwebsite.com/images/7324204/3</li>  <li>可接受：http://www.yourwebsite.com/images/dress.jpg</li>  <li>不能接受：https://www.your website.com/images/7324204/3</li>  <li>不能接受：http://www.yourwebsite.com/images/dresses.html</li>  </ul>"
  },
  "ExtraImageURL6":{
  	"Type":"URL",
  	"Description":"产品照片的 URL。直接链接到图片，而不是它所在的页面。与主图片 URL（默认图片）相同的规则适用。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：http://www.yourwebsite.com/images/7324204/3</li>  <li>可接受：http://www.yourwebsite.com/images/dress.jpg</li>  <li>不能接受：https://www.your website.com/images/7324204/3</li>  <li>不能接受：http://www.yourwebsite.com/images/dresses.html</li>  </ul>"
  },
  "ExtraImageURL7":{
  	"Type":"URL",
  	"Description":"产品照片的 URL。直接链接到图片，而不是它所在的页面。与主图片 URL（默认图片）相同的规则适用。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：http://www.yourwebsite.com/images/7324204/3</li>  <li>可接受：http://www.yourwebsite.com/images/dress.jpg</li>  <li>不能接受：https://www.your website.com/images/7324204/3</li>  <li>不能接受：http://www.yourwebsite.com/images/dresses.html</li>  </ul>"
  },
  "ExtraImageURL8":{
  	"Type":"URL",
  	"Description":"产品照片的 URL。直接链接到图片，而不是它所在的页面。与主图片 URL（默认图片）相同的规则适用。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：http://www.yourwebsite.com/images/7324204/3</li>  <li>可接受：http://www.yourwebsite.com/images/dress.jpg</li>  <li>不能接受：https://www.your website.com/images/7324204/3</li>  <li>不能接受：http://www.yourwebsite.com/images/dresses.html</li>  </ul>"
  },
  "ExtraImageURL9":{
  	"Type":"URL",
  	"Description":"产品照片的 URL。直接链接到图片，而不是它所在的页面。与主图片 URL（默认图片）相同的规则适用。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：http://www.yourwebsite.com/images/7324204/3</li>  <li>可接受：http://www.yourwebsite.com/images/dress.jpg</li>  <li>不能接受：https://www.your website.com/images/7324204/3</li>  <li>不能接受：http://www.yourwebsite.com/images/dresses.html</li>  </ul>"
  },
  "ExtraImageURL10":{
  	"Type":"URL",
  	"Description":"产品照片的 URL。直接链接到图片，而不是它所在的页面。与主图片 URL（默认图片）相同的规则适用。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：http://www.yourwebsite.com/images/7324204/3</li>  <li>可接受：http://www.yourwebsite.com/images/dress.jpg</li>  <li>不能接受：https://www.your website.com/images/7324204/3</li>  <li>不能接受：http://www.yourwebsite.com/images/dresses.html</li>  </ul>"
  },
  "WarehouseName":{
  	"Type":"String",
  	"Description":"请为您内部使用的仓库提供唯一名称来标识它。运费和库存仅适用于指定仓库。若您未特别指定一个仓库，则这些数据将适用您账户所对应的默认仓库。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：US_94132</li>  <li>可接受：SZ_CN</li>  <li>不能接受：2</li>  <li>不能接受：a</li>  </ul>"
  },
  "Enable":{
  	"Type":"Integer",
  	"Description":"在 Wish 上启用此 SKU。用户将能够查看和购买产品。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：1</li>  <li>不能接受：True</li>  <li>不能接受：Enable</li>  </ul>"
  },
  "Disable":{
  	"Type":"Integer",
  	"Description":"在 Wish 上禁用此 SKU。用户将无法查看或购买产品。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：1</li>  <li>不能接受：True</li>  <li>不能接受：Disable</li>  </ul>"
  },
  "OrderNo":{
  	"Type":"String",
  	"Description":"Wish 的订单唯一 编号，您可以在导出的交易 csv 文件的 Order No 列下找到此 编号。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：201804170002</li></ul>"
  },
  "ShippingProvider":{
  	"Type":"String",
  	"Description":"将您的包裹运送到目的地的承运人",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：USPS</li>  <li>可接受：ChinaPost</li>  <li>不能接受：China Post</li>  </ul>"
  },
  "TrackingNumber":{
  	"Type":"String",
  	"Description":"您的承运人提供的唯一 ID，可供用户在包裹运送过程中跟踪包裹。",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：9400109699937997957086</li>  <li>不能接受：9400109 699 937997 95 70 86</li>  <li>不能接受：N/A</li>  </ul>"
  },
   "ShipNote":{
  	"Type":"String",
  	"Description":"给您自己的备注",
  	"Examples":"<ul class=\"example-list\">  <li>可接受：Reference ID: ABC0001</li>  </ul>"
  }
}
