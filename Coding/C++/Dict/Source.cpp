#include <stdio.h>
#include <stdlib.h>
#include <iostream>
#include <vector>
#include <string>
#include <stdexcept>


// �������� ������� �� Dr.Web �� ����� hh.ru �� ��������� C++ 
// ��� ��������� �++ ������������ 
//
// ��������� ���������� ������ ������� � ���������, ���������� �
// ����������� ������. ��� �� ������� ������ �������� ������
// ��� ������� ���������� � ��������������� ��������
//
// ��������� ���������� ����� vector ��� ����������� � ����������
// ���������� � ��������� ������� �� ������ ����������



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
        return "���� �� ������!\n";
    }
};

template<class Key, class Value>
class NewDictinary :dictionary<Key, Value>
{
private:
    vector<Key> keys;
    vector<Value> values;
    int size;
    int find(const Key& k) const
    {
        for (int i = 0; i < size; i++)
        {
            if (k == keys[i]) return i;
        }
        return -1;
    }
public:
    NewDictinary(const Key& k, const Value& v)
    {
        keys.push_back(k);
        values.push_back(v);
        size = 1;
    }
    const Value& get(const Key& key) const override
    {
        int t = find(key);
        if (t == -1) throw not_found_exception_dictionary<Key>(key);
        else return values[t];
    }
    void set(const Key& key, const Value& value) override
    {
        int f = find(key);
        if (f == -1)
        {
            keys.push_back(key);
            values.push_back(value);
            size++;
        }
        else
        {
            values[f] = value;
        }
    }
    bool is_set(const Key& key) const override
    {
        if (find(key) == -1) return false;
        else return true;
    }
    void show_all()
    {
        if (size > 0) for (int i = 0; i < size; i++)
        {
            cout << keys[i] << " " << values[i] << endl;
        }
    }
};


enum Options { exist, show, set, getit, exitit };

int main()
{
    setlocale(LC_ALL, "ru");
    auto d1 = new NewDictinary<string, string>("Test_key", "Test_value");
    cout << "��� ������ �������� �������!\n";
    string str;
    string str1;
    int com;
    while (true)
    {
        cout << "��������� �������: exist, show, set, get, exit\n";
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
            cout << "������� ���� ��� ������: ";
            cin >> str;
            if (d1->is_set(str)) cout << "���� ����������!\n";
            else cout << "����� ���!\n";
        };
        break;
        case set:
        {
            cout << "������� ����: ";
            cin >> str;
            cout << "������� ��������: ";
            cin >> str1;
            d1->set(str, str1);
            cout << "�������� ��������� ��� ���������!\n";
        };
        break;
        case getit:
        {
            cout << "������� ����: ";
            cin >> str;
            try
            {
                str1 = d1->get(str);
                cout << "�������� �� ��������� ����� - " + str1 << endl;
            }
            catch (not_found_exception_dictionary<string> ex)
            {
                cout << "���������� ���� " + ex.get_key() << endl;
                cout << ex.what();
            }
        };
        break;
        default: cout << "����������� �������!\n";
            break;
        }
    }
    return 0;
}