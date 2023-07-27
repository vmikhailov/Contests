#include <iostream>

class TextInput
{
public:
    virtual void add(char c) {
        _data += c;
            }

    std::string getValue() { return _data; }

private:
    std::string _data;
};

class NumericInput : public TextInput {
public :
    void add(char c) override{
        if(std::isdigit(c)){
            TextInput::add(c);
        }
    }
};