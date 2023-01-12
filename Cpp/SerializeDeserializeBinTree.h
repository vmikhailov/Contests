#include <string>
#include <sstream>

using namespace std;

class SerializeDeserializeBinTree {
public:

    // Encodes a tree to a single string.
    string serialize(TreeNode *root) {
        stringstream ss;
        serialize(root, ss);
        return ss.str();
    }

    // Decodes your encoded data to tree.
    TreeNode *deserialize(string data) {
        if (data.size() == 0) return nullptr;
        stringstream ss = stringstream(data);

        auto tree = deserialize(&ss);
        return tree;
    }

private:
    void serialize(TreeNode *root, stringstream &ss) {
        if (root) {
            ss << root->val;
            if(root->left) {
                ss << 'L';
                serialize(root->left, ss);
            }
            if(root->right) {
                ss << 'R';
                serialize(root->right, ss);
            }
            ss << 'U';
        }
    }

    TreeNode *deserialize(stringstream *ss) {
        int v;
        char c;
        *ss >> v;
        auto root = new TreeNode(v);
        while(true){
            *ss >> c;

            switch (c) {
                case 'L':
                    root->left = deserialize(ss);
                    break;
                case 'R':
                    root->right = deserialize(ss);
                    break;
                case 'U':
                default:
                    return root;
            }
        }
    }
};