#include <unordered_set>
#include <unordered_map>

namespace bimap2 {
    template<typename KeyType, typename ValueType>
    struct Bimap {
        typedef std::unordered_set<KeyType> Keys;
        typedef std::unordered_map<KeyType, ValueType> Map;
        typedef std::unordered_map<ValueType, Keys> ReversedMap;

        void set(const KeyType &key, const ValueType &value) {
            _map.insert(std::make_pair(key, value));
            _reversedMap[value].insert(key);
        }

        Keys& keysByValue(const ValueType& value){
            return _reversedMap.at(value);
        }

        ValueType& valueByKey(const KeyType& key){
            return _map.at(key);
        }

        void removeKey(const KeyType &key) {
            if (!hasKey(key)) return;

            auto value = _map[key];
            Keys keys = _reversedMap[value];
            _map.erase(key);
            keys.erase(key);
            if(keys.empty())
            {
                _reversedMap.erase(value);
            }
        }

        bool hasKey(const KeyType &key) {
            return _map.find(key) != _map.end();
        }

        [[nodiscard]]
        unsigned int size() const {
            return _map.size();
        }

    private:
        Map _map;
        ReversedMap _reversedMap;
    };
}