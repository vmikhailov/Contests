#ifndef CPP_BIMAP_H
#define CPP_BIMAP_H

#include <unordered_map>
#include <map>
#include <unordered_set>

namespace bimap {
    template <typename KeyType, typename ValueType>
    struct Bimap {
        typedef std::unordered_set<KeyType> Keys;
        typedef std::unordered_map<KeyType, ValueType> KeyMap;
        typedef std::unordered_map<ValueType, Keys> ValueMap;

        void set(const KeyType& key, const ValueType& value) {
            _normalMap.insert(std::make_pair(key, value));
            _transposeMap[value].insert(key);
        }

        Keys& keysForValue(const ValueType &value) {
            return _transposeMap.at(value);
        }

        ValueType& valueForKey(const KeyType &key) {
            return _normalMap.at(key);
        }

        bool removeKey(const KeyType& key) {
            auto has = hasKey(key);
            if (has) {

                auto &value = valueForKey(key);
                auto &keys = keysForValue(value);
                keys.erase(key);
                if (keys.empty()) {
                    _transposeMap.erase(value);
                }

                _normalMap.erase(key);
            }

            return has;
        }

        bool removeValue(const ValueType& value) {
            auto has = hasValue(value);
            if (has) {

                auto &keys = keysForValue(value);
                for (auto item : keys) {
                    _normalMap.erase(item);
                }

                _transposeMap.erase(value);
            }

            return has;
        }

        bool hasKey(const KeyType& key) const {
            return _normalMap.find(key) != _normalMap.end();
        }

        bool hasValue(const ValueType& value) const {
            return _transposeMap.find(value) != _transposeMap.end();
        }

        [[nodiscard]] unsigned long size() const {
            return _normalMap.size();
        }

        const ValueMap& left() const {
            return _transposeMap;
        };

        const KeyMap& right() const {
            return _normalMap;
        };

    private:

        KeyMap _normalMap;
        ValueMap _transposeMap;
    };
}


#endif //CPP_BIMAP_H
