using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryDisplay : MonoBehaviour
{
    ListNode current;
    
    public GameObject net;
    public GameObject hands;
    public GameObject twoFireflies;
    public GameObject threeFireflies;
    public GameObject comb1;
    public GameObject combfinal;

    public GameObject[] invDisplay;
    private bool invUp;
    public GameObject invText;
    public GameObject panel;

    public MessageDisplay M; 

    bool firstItem = true;
    bool combAnimation = false;

    public MouseController controller;

    public bool hasItem(string name)
    {
        return (find(name) != null);
    }

    public string held()
    {
        return current.getName();
    }

    public void itemAdded(string name, GameObject value)
    {
        if(firstItem)
        {
            M.ShowMessage("Press z to swap between items!");
            firstItem = false;
        }
        if(find(name)!=null)
        {
            return;
        }
        ListNode newNode = new ListNode(current.getNext(), name, value);
        current.setNode(newNode);
        current = newNode;
        updateImage();
    }

    void updateImage()
    {
        // update the sprite to be the current one
        GetComponent<Image>().sprite = current.getVal().GetComponent<SpriteRenderer>().sprite;
        Image image = GetComponent<Image>();
        var tempColor = image.color;
        if (current.getName().Equals("nothing"))
        {
            tempColor.a = 0f;
            image.color = tempColor;
        }
        else
        {
            tempColor.a = 255f;
            image.color = tempColor;
        }
        // Hold the current item
        controller.holdObject(current.getVal());
    }

    void showFull()
    {
        ListNode start = current;
        if (current.getName().Equals("nothing"))
        {
            start = current.getNext();
        }
        ListNode tempNode = start;
        int i = 0;
        do
        {
            if (tempNode.getName().Equals("nothing"))
            {
                tempNode = tempNode.getNext();
                continue;
            }
            Image image = invDisplay[i].GetComponent<Image>();
            image.sprite = tempNode.getVal().GetComponent<SpriteRenderer>().sprite;
            var tempColor = image.color;
            tempColor.a = 255f;
            image.color = tempColor;

            i++;
            tempNode = tempNode.getNext();
        }
        while (!tempNode.Equals(start));
        var temp = invText.GetComponent<Text>().color;
        temp.a = 255f;
        invText.GetComponent<Text>().color = temp;
        temp = panel.GetComponent<Image>().color;
        temp.a = 200f;
        panel.GetComponent<Image>().color = temp;
    }

    void hideFull()
    {
        for(int i = 0;i<invDisplay.Length;i++)
        {
            Image image = invDisplay[i].GetComponent<Image>();
            var tempColor = image.color;
            tempColor.a = 0f;
            image.color = tempColor;
        }
        var temp = invText.GetComponent<Text>().color;
        temp.a = 0f;
        invText.GetComponent<Text>().color = temp;
        temp = panel.GetComponent<Image>().color;
        temp.a = 0f;
        panel.GetComponent<Image>().color = temp;
    }

    public void itemRemoved(string name)
    {
        ListNode prev = find(name);
        if(current.getName() == name)
        {
            current = prev;
        }
        prev.setNode(prev.getNext().getNext());
        updateImage();
    }

    private ListNode find(string itemName)
    {// none stick
        ListNode iter = current.getNext();
        string startName = current.getName(); 
        while (!itemName.Equals(iter.getNext().getName()) && !startName.Equals(iter.getName()))
        {
            iter = iter.getNext();
        }
        if (itemName.Equals(iter.getNext().getName()))
            return iter;
        else
            return null;
    }

    private void Start()
    {
        current = new ListNode("nothing", hands);
        // update the sprite to be the current one
        GetComponent<Image>().sprite = current.getVal().GetComponent<SpriteRenderer>().sprite;
        // Hold the current item
        controller.holdObject(current.getVal());
    }

    private void Update()
    {
        // Check if full inventory should be shown
        if (Input.GetKey("i") && !invUp)
        {
            invUp = true;
            showFull();
        }
        else if(!Input.GetKey("i") && invUp)
        {
            invUp = false;
            hideFull();
        }
        // Combine items for net
        if (find("stick") != null && find("net") == null && find("yarn") != null)
        {
            //combine("net", "stick", "yarn");
            itemAdded("net", net);
            itemRemoved("stick");
            itemRemoved("yarn");
        }
        //combine fireflies
        if(find("firefly1") != null && find("firefly2") != null && find("twofireflies") == null && find("threefireflies") == null)
        {
            itemAdded("twofireflies", twoFireflies);
            itemRemoved("firefly1");
            itemRemoved("firefly2");
        }
        else if (find("firefly3") != null && find("firefly2") != null && find("twofireflies") == null && find("threefireflies") == null)
        {
            itemAdded("twofireflies", twoFireflies);
            itemRemoved("firefly3");
            itemRemoved("firefly2");
        }
        else if (find("firefly1") != null && find("firefly3") != null && find("twofireflies") == null && find("threefireflies") == null)
        {
            itemAdded("twofireflies", twoFireflies);
            itemRemoved("firefly1");
            itemRemoved("firefly3");
        }
        if (find("firefly1") != null && find("twofireflies") != null && find("threefireflies") == null)
        {
            itemAdded("threefireflies", threeFireflies);
            itemRemoved("firefly1");
            itemRemoved("twofireflies");
        }
        else if (find("firefly2") != null && find("twofireflies") != null && find("threefireflies") == null)
        {
            itemAdded("threefireflies", threeFireflies);
            itemRemoved("firefly2");
            itemRemoved("twofireflies");
        }
        else if (find("firefly3") != null && find("twofireflies") != null && find("threefireflies") == null)
        {
            itemAdded("threefireflies", threeFireflies);
            itemRemoved("firefly3");
            itemRemoved("twofireflies");
        }

        if (Input.GetKeyDown("z"))
        {
            current = current.getNext();
            updateImage();
        }

        if (combAnimation == true)
        {
            Vector3 finalpos = new Vector3(combfinal.transform.position.x,
            combfinal.transform.position.y, combfinal.transform.position.z);
            comb1.transform.position = Vector3.MoveTowards(comb1.transform.position,
                finalpos, 100f * Time.deltaTime);
        }
        
    }

    private class ListNode
    {
        ListNode next;
        string name;
        GameObject value;

        public ListNode(ListNode head,string Iname,GameObject Ivalue)
        {
            next = head;
            this.name = Iname;
            this.value = Ivalue;
        }

        public ListNode(string Iname, GameObject Ivalue)
        {
            next = this;
            this.name = Iname;
            this.value = Ivalue;
        }

        public void setNode(ListNode newNode)
        {
            next = newNode;
        }

        public ListNode getNext()
        {
            return next;
        }

        public string getName()
        {
            return name;
        }

        public GameObject getVal()
        {
            return value;
        }
    }

    private void combine(string final, string part1, string part2)
    {
        print("Combine");
        comb1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(part1);
    }
}

