using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
app.MapGet("/read", async (HttpContext http) =>
{
    await foreach (var c in Handle())
    {
        await http.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(c.ToString()));
        await http.Response.Body.FlushAsync();
    }

    await http.Response.CompleteAsync();
});
app.Run();

async IAsyncEnumerable<char> Handle()
{
    foreach (var c in LongString())
    {
        await Task.Delay(10);
        yield return c;
    }
}

static string LongString() => """
7-11優惠快收下！為了歡慶職棒統一獅隊勇奪2023年上半球季封王，7-11祭出一連串優惠，包括CITY CAFE濃萃美式咖啡買1送1、濃萃拿鐵咖啡買2送1 ; 超過300項商品第二件5折。此外CITY PRIMA與金曲獎合作，推出熱飲限定的金曲獎杯套，以及CITY PRIMA大杯同品項第二杯10元，快揪好友一起去7-11喝咖啡！

買一送一！7-11賀統一獅隊2023年上半季封王推出「咖啡優惠」
爲了慶祝統一7-ELEVEn獅隊勇奪2023年上半球季封王，喜迎隊史上第16座季冠軍，7-11門市自6月30日起祭出指定CITY系列、熱狗/大亨堡以及統一系列商品優惠，咖啡優惠自6月30日起至7月3日止連續四天，推出CITY CAFE濃萃美式咖啡買1送1及CITY CAFE濃萃拿鐵咖啡買2送1優惠。

行動隨時取則自7月1日起限量推出指定飲料、乳品、冰品等組合優惠，最低66折起；另自7月1日起至7月3日止連續三天，帶來熱狗/大亨堡以及統一飲料、麵包、泡麵、冰品、甜點、食材調味品等指定商品任選第二件5折優惠活動，各位快去爆買一波！

7-11 CITY CAFE攜手「LINE禮物」推數位贈禮，還免費送咖啡
CITY CAFE跨界合作LINE禮物自7月1日至7月20日止，只要選購CITY CAFE中杯熱美式咖啡送禮，收禮者兌領後，送禮者即可額外獲贈乙杯免費「中熱美式咖啡」限量10萬組。此外，CITY PRIMA連續4年與金曲獎合作，推出熱飲限定的金曲獎杯套，更於6月28日起至7月9日推出CITY PRIMA大杯同品項第二杯10元優惠。

7-11 CITY CAFE攜手「LINE禮物」推數位贈禮，還免費送咖啡
CITY CAFE跨界合作LINE禮物自7月1日至7月20日止，只要選購CITY CAFE中杯熱美式咖啡送禮，收禮者兌領後，送禮者即可額外獲贈乙杯免費「中熱美式咖啡」限量10萬組。此外，CITY PRIMA連續4年與金曲獎合作，推出熱飲限定的金曲獎杯套，更於6月28日起至7月9日推出CITY PRIMA大杯同品項第二杯10元優惠。
""";