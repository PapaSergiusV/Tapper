#include <iostream>
#include <string>
#include <cassert>
#include <chrono>

using namespace std;

// Проверка числа в строковом формате на наличие сторонних элементов
bool checkNum(const string& num)
{
	for (char c : num)
	{
		if (!isdigit(c))
			return false;
	}
	return true;
}

// Делит число любого размера на 2, возвращает пару: 'частное,остаток'
string div2(const string& num)
{
	if (!checkNum(num))
		return ("error: wrong number", "error");
	string res;
	int rem = num[0] == '1' ? 1 : 0, current;

	for (unsigned int i = rem; i < num.length(); i++)
	{
		char curChar = num[i];
		current = atoi(&curChar);
		res.append(1, (char)((current + rem * 10) / 2 + 48));
		rem = current % 2;
	}
	return res.append(1, ',').append(1, static_cast<char>(rem + 48));
}

// Делит число любого размера на 17
string div17(const string& num)
{
	if (!checkNum(num))
		return ("error: wrong number", "error");
	string res;
	char first = num[0];
	int rem = atoi(&first), current;

	for (unsigned int i = 1; i < num.length(); i++)
	{
		char curChar = num[i];
		current = atoi(&curChar) + rem * 10;
		rem = current % 17;
		current = current / 17;
		if (!(current == 0 && res.length() == 0))
			res.append(1, static_cast<char>(current + 48));
	}
	if (res.length() == 0)
		return "0";
	return res;
}

// Возвращает двоичное число в строковом формате бесконечно большого числа, записанного в строковом формате в 10-й системе счисления
string convertToBinaryReverse(string num)
{
	auto t1 = chrono::system_clock::now();

	if (!checkNum(num))
		return ("error: wrong number", "error");
	string res, crude;

	while (num.length() > 0)
	{
		crude = div2(num);
		num = crude.substr(0, crude.length() - 2);
		res.append(crude.substr(crude.length() - 1));
	}

	auto t3 = chrono::system_clock::now();
	cout << "Conv:\t" << chrono::duration_cast<std::chrono::milliseconds>(t3 - t1).count() << " ms" << endl;

	return res;
}

// Добавляет нули спереди к бинарному числу до длины 1802 знака
string toFormat106x17(const string& num)
{
	int need = 1802 - num.length();
	if (need == 0)
		return num;
	if (need < 0)
		return "error: num > 1802";
	string res;
	return res.append(need, '0').append(num);
}

// Печать бинарного числа 106 х 17
void printPic(const string& bin)
{
	auto t1 = chrono::system_clock::now();
	if (bin.length() != 1802)
		cout << "error: bin count != 1802" << endl;

	for (int i = 16; i >= 0; i--)
	{
		for (int j = 0; j < 106; j++)
		{
			cout << (bin[i + 17 * j] == '1' ? "X" : " ");
		}
		cout << endl;
	}
	auto t3 = chrono::system_clock::now();
	cout << "Print:\t" << chrono::duration_cast<std::chrono::milliseconds>(t3 - t1).count() << " ms" << endl;
}


int main()
{
	////div2 tests
	//string s = "281";	assert(div2(s) == "140,1");
	//s = "0";			assert(div2(s) == "0,0");
	//s = "1200";			assert(div2(s) == "600,0");
	//s = "3";			assert(div2(s) == "1,1");
	//s = "337";			assert(div2(s) == "168,1");
	//s = "2";			assert(div2(s) == "1,0");
	//s = "9999";			assert(div2(s) == "4999,1");

	////div17 tests
	//s = "51";			assert(div17(s) == "3");
	//s = "170";			assert(div17(s) == "10");
	//s = "17";			assert(div17(s) == "1");
	//s = "120";			assert(div17(s) == "7");
	//s = "5643";			assert(div17(s) == "331");
	//s = "3";			assert(div17(s) == "0");
	//s = "12";			assert(div17(s) == "0");

	////convertToBinaryReverse tests
	//assert(convertToBinaryReverse("1201")	== "10001101001");
	//assert(convertToBinaryReverse("8")		== "0001");
	//assert(convertToBinaryReverse("239")	== "11110111");
	//assert(convertToBinaryReverse("15")		== "1111");

	////toFormat106x17 test
	//s = toFormat106x17(s);
	//assert(s.length() == 1802);

	//PROGRAM

	//string num = "4858450636189713423582095962494202044581400587983244549483093085061934704708809928450644769865524364849997247024915119110411605739177407856919754326571855442057210445735883681829823754139634338225199452191651284348332905131193199953502413758765239264874613394906870130562295813219481113685339535565290850023875092856892694555974281546386510730049106723058933586052544096664351265349363643957125565695936815184334857605266940161251266951421550539554519153785457525756590740540157929001765967965480064427829131488548259914721248506352686630476300";
	string num = "4858487703217654168507377107565676789145697178497253677539145555247620343537955749299116772611982962556356527603203744742682135448820545638134012705381689785851604674225344958377377969928942310236199337805399065932982909660659786056259547094494380793146587709009524498386724160055692719747815828234655968636671461350354316223620304956111171025410498514602810746287134775641383930152393933036921599511277388743068766568352667661462097979110006690900253037600818522726237351439443865433159187625289316917268254866954663750093103703327097252478959";
	auto t1 = chrono::system_clock::now();
	num = convertToBinaryReverse(div17(num));
	num = toFormat106x17(num);
	printPic(num);
	auto t3 = chrono::system_clock::now();
	cout << "All:\t" << chrono::duration_cast<std::chrono::milliseconds>(t3 - t1).count() << " ms" << endl;

	system("pause");
}