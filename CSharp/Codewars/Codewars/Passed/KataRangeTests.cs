using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    [TestFixture]
    public class KataRangeTests
    {
        [Test,Description("5 Example Tests"),TestCaseSource("Examples")]
        public void ExampleTest(string s,int n,int[] sol){
            Assert.That(KataRange.MysteryRange(s,n),Is.EqualTo(sol));}
	
        public object[][] Examples =
        [
            [
                "39632948356195827637981283711627103675069365786265156231996865211355901733707374228084669641349301040724543755311207918854974765178583288544614199287422389941023828817785244245956251011006410491936097",100, new[]{5, 104}
            ],
            ["6291211413114538107",14,new int[2]{1,14}],
            ["13161820142119101112917232215",15,new int[2]{9,23}],
            ["2318134142120517221910151678611129",20,new int[2]{4,23}],
            ["10610211511099104113100116105103101111114107108112109",18,new int[2]{99,116}],
            [
                "1721532418565922162558663126649136347436733301144143236653738464135820194215516155541239452852623450572927602348104049",60,new int[2]{8,67}
            ]
        ];
    }
}