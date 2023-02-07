#include <stdio.h>
#include <stdlib.h>
#include <iostream>
#include <string>
#include <stdexcept>
#include <unordered_map>

using namespace std;

template<class Key, class Value>
class dictionary
{
public:
    virtual ~dictionary() = default;

    virtual const Value& get(const Key& key) const = 0;
    virtual void set(const Key& key, const Value& value) = 0;
    virtual bool is_set(const Key& key) const = 0;
};


template<class Key>
class not_found_exception : public exception
{
public:
    virtual const Key& get_key() const noexcept = 0;
};
template<class Key>
class not_found_exception_dictionary : public not_found_exception <Key>
{
    Key errorKey;
public:
    not_found_exception_dictionary(const Key& k)
    {
        errorKey = k;
    }
    const Key& get_key() const noexcept override
    {
        return errorKey;
    };
    const char* what()
    {
        return "Ключ не найден!\n";
    }
};

template<class Key, class Value>
class NewDictinary :dictionary<Key, Value>
{
private:
    unordered_map<Key, Value> dic;
public:
    NewDictinary(const Key& k, const Value& v)
    {
        dic[k] = v;
    }
    const Value& get(const Key& key) const override
    {
        if(dic.count(key) ==0) throw not_found_exception_dictionary<Key>(key);
        else return dic.at(key);
    }
    void set(const Key& key, const Value& value) override
    {
        if (dic.count(key) == 0) dic[key] = value;
        else dic[key] = value;
    }
    bool is_set(const Key& key) const override
    {
        return (dic.count(key)>0) ? true : false;
    }
    void show_all()
    {
        for (auto it: dic)
        {
            cout << it.first << " " << it.second << endl;
        }
    }
};


enum Options { exist, show, set, getit, exitit };

int main()
{
    setlocale(LC_ALL, "ru");
    auto d1 = new NewDictinary<string, string>("Test_key", "Test_value");
    cout << "Был создан тестовый словарь!\n";
    string str;
    string str1;
    int com;
    while (true)
    {
        cout << "Доступные команды: exist, show, set, get, exit\n";
        cin >> str;
        com = -1;
        if (str == "exist") com = exist;
        if (str == "show") com = show;
        if (str == "set") com = set;
        if (str == "get") com = getit;
        if (str == "exit") com = exitit;
        switch (com)
        {
        case exitit: return 0;
            break;
        case show: d1->show_all();
            break;
        case exist:
        {
            cout << "Введите ключ для поиска: ";
            cin >> str;
            if (d1->is_set(str)) cout << "Ключ существует!\n";
            else cout << "Ключа нет!\n";
        };
        break;
        case set:
        {
            cout << "Введите ключ: ";
            cin >> str;
            cout << "Введите значение: ";
            cin >> str1;
            d1->set(str, str1);
            cout << "Значения добавлены или обновлены!\n";
        };
        break;
        case getit:
        {
            cout << "Введите ключ: ";
            cin >> str;
            try
            {
                str1 = d1->get(str);
                cout << "Значение по заданному ключу - " + str1 << endl;
            }
            catch (not_found_exception_dictionary<string> ex)
            {
                cout << "Проблемный ключ " + ex.get_key() << endl;
                cout << ex.what();
            }
        };
        break;
        default: cout << "Неизвестная команда!\n";
            break;
        }
    }
    return 0;
}