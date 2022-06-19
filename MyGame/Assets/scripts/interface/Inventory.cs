using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject Inventory_menu;
    public GameObject[] weapons_arr;
    public GameObject[] grenades_arr;
    public GameObject[] skins_arr;
    public GameObject[] now_skin;
    public GameObject pistol;
    public GameObject shotgun;
    public GameObject ak_47;
    public GameObject rpg;
    public GameObject p_90;
    public GameObject snowgun;
    public GameObject stick;
    public GameObject axe;
    public GameObject punk, skin_1, defoalt;
    public GameObject inv_punk, inv_skin_1, inv_bill;
    public GameObject infantry_grenade,dynamite,ice_grenade;
    public bool clear;
    public GameObject fon;
    public int i;
    public int s_i;
    private int j = 0;
    private int k = 0, w, s, t, g;
    public Image img;
    public int[] now_weapon;
    public GameObject[] cells_arr;
    public GameObject[] g_cells_arr;
    public int[] cell_ind_arr = { 0, 0, 0, 0, 0, 0 };
    public int[] g_cell_ind_arr = { 0, 0, 0, 0, 0, 0 };
    public GameObject light_1; public GameObject light_2; public GameObject light_3; public GameObject light_4; public GameObject light_5; public GameObject light_6;
    private GameObject[] light;
    public Image weapon_sprite,grenade_sprite;
    public Image cell_sprite,g_cell_sprite;
    public inventory_weapon script;
    public inventory_grenade g_script;
    public Save save_script;
    public GameObject cell1, cell2, cell3, cell4, cell5, cell6;
    public GameObject g_cell1, g_cell2, g_cell3, g_cell4, g_cell5, g_cell6;
    private string[] category = { "weapon", "skins", "grenade" };
    private int category_i;
    public GameObject cat_text;
    private Text category_text;
    private change_weapon change_weapon;
    public SpriteRenderer bill_sprite;
    private bill bill;

    public GameObject weapons_menu;
    public GameObject skins_menu;
    public GameObject granage_menu;
    public GameObject traps_menu;
    public bool stop;
    void Start()
    {
        fon.SetActive(false);
        light = new GameObject[6];
        light[0] = light_1;light[1] = light_2;light[2] = light_3;light[3] = light_4;light[4] = light_5;light[5] = light_6;
        category_i = 0;
        //category_text = cat_text.GetComponent<Text>();
        save_script = GameObject.Find("save").GetComponent<Save>();
        change_weapon = GameObject.Find("Bill").GetComponent<change_weapon>();
        save_script.Load_weapon();
        save_script.Load_grenades();
        j = save_script.inv_j;
        k = save_script.inv_k;
        now_weapon = new int[2];
        now_weapon[0]=-1; now_weapon[1] = -1;
        i = 0;
        bill_sprite = GameObject.Find("Bill").GetComponent<SpriteRenderer>();
        weapons_arr = new GameObject[8];
        weapons_arr[0] = pistol;weapons_arr[1] = shotgun;weapons_arr[2] = ak_47; weapons_arr[3] = rpg;weapons_arr[4] = p_90; weapons_arr[5] = snowgun;weapons_arr[6] = stick;weapons_arr[7] = axe;
        cells_arr = new GameObject[6];
        cells_arr[0] = cell1;cells_arr[1] = cell2; cells_arr[2] = cell3; cells_arr[3] = cell4; cells_arr[4] = cell5; cells_arr[5] = cell6;
        g_cells_arr = new GameObject[6];
        g_cells_arr[0] = g_cell1; g_cells_arr[1] = g_cell2; g_cells_arr[2] = g_cell3; g_cells_arr[3] = g_cell4; g_cells_arr[4] = g_cell5; g_cells_arr[5] = g_cell6;
        grenades_arr = new GameObject[3];
        grenades_arr[0] = infantry_grenade;grenades_arr[1] = dynamite;grenades_arr[2] = ice_grenade;
        skins_arr = new GameObject[3];
        skins_arr[0]=defoalt; skins_arr[1] = skin_1;skins_arr[2] = punk;
        now_skin = new GameObject[3];
        now_skin[0] = inv_bill;now_skin[1] = inv_skin_1;now_skin[2] = inv_punk;
        bill = GameObject.Find("Bill").GetComponent<bill>();
        weapon_trans = weapon_category.GetComponent<RectTransform>();
        skins_trans= skins_category.GetComponent<RectTransform>();
        traps_trans= traps_category.GetComponent<RectTransform>();
        granage_trans= granage_category.GetComponent<RectTransform>();
        cells = new GameObject[12];
        cells[0] = weapon_cell_1;cells[1] = weapon_cell_2;cells[2] = weapon_cell_3;cells[3] = skins_cell_1;cells[4] = skins_cell_2;cells[5] = skins_cell_3;cells[6] = traps_cell_1;cells[7] = traps_cell_2;cells[8] = traps_cell_3;cells[9] = granage_cell_1;cells[10] = granage_cell_2;cells[11] = granage_cell_3;
        cells_pos = new float[12,2];
        for(int k = 0; k < 12; k++)
        {
            cell = cells[k].GetComponent<RectTransform>();
            cells_pos[k,0] = cell.anchoredPosition.x;cells_pos[k,1] = cell.anchoredPosition.y;
        }
        Weapon();
    }

    void Update()
    {
        //category_text.text = category[category_i];   
    }
    public void Inventory_ON()
    {
        Inventory_menu.SetActive(true);
        bill_sprite.sortingOrder = 16;
        fon.SetActive(true);
        clear = true;
        bill.stop = true;
        bill.rb.velocity = new Vector2(0f, 0f);
        bill.transform.position = new Vector3(6.5f, bill.transform.position.y, bill.transform.position.z);
        ZoomCamera.zoom = 0.4f;
        bill.weapons.SetActive(true);
    }
    public void Inventory_OFF()
    {
        Inventory_menu.SetActive(false);
        fon.SetActive(false);
        bill_sprite.sortingOrder = 9;
        ZoomCamera.zoom = 0.7f;
        bill.stop = false;
        bill.weapons.SetActive(false);
        for (int i = 0; i < 9; i++)
            change_weapon.weapons[i].SetActive(false);
    }
    public void Weapon_OFF()
    {
        weapons_arr[i].SetActive(false);
    }
    public void Weapon_ON()
    {
        weapons_arr[i].SetActive(true);
        img = weapons_arr[i].GetComponent<Image>();
    }
    public void Grenade_OFF()
    {
        grenades_arr[i].SetActive(false);
    }
    public void Grenade_ON()
    {
        grenades_arr[i].SetActive(true);
        img = grenades_arr[i].GetComponent<Image>();
    }
    public void Skin_OFF()
    {
        skins_arr[s_i].SetActive(false);
        now_skin[s_i].SetActive(false);
    }
    public void Skin_ON()
    {
        skins_arr[s_i].SetActive(true);
        now_skin[s_i].SetActive(true);
    }
    public void NewWeapon()
    {
        save_script.Load_weapon();
        j = save_script.inv_j;
        ChekSells();
        script = cells_arr[j].GetComponent<inventory_weapon>();
        script.i = i;
        cell_sprite = cells_arr[j].GetComponent<Image>();
        weapon_sprite = weapons_arr[i].GetComponent<Image>();
        cell_sprite.sprite = weapon_sprite.sprite;
    }
    public void NewGrenade()
    {
        save_script.Load_grenades();
        k = save_script.inv_k;
        ChekGrenadeSells();
        g_script = g_cells_arr[k].GetComponent<inventory_grenade>();
        g_script.i = i;
        g_cell_sprite = g_cells_arr[k].GetComponent<Image>();
        grenade_sprite = grenades_arr[i].GetComponent<Image>();
        g_cell_sprite.sprite = grenade_sprite.sprite;
    }
    public void ChekSells()
    {
        for (int x = 0; x <= j; x++)
        {
            cell_ind_arr = save_script.save_cell_ind_arr;
            cells_arr[x].SetActive(true);
            script = cells_arr[x].GetComponent<inventory_weapon>();
            script.i = cell_ind_arr[x];
            cell_sprite = cells_arr[x].GetComponent<Image>();
            weapon_sprite = weapons_arr[script.i].GetComponent<Image>();
            cell_sprite.sprite = weapon_sprite.sprite;
        }
    }
    public void ChekGrenadeSells()
    {
        for (int x = 0; x <= k; x++)
        {
            g_cell_ind_arr = save_script.save_g_cell_ind_arr;
            g_cells_arr[x].SetActive(true);
            g_script = g_cells_arr[x].GetComponent<inventory_grenade>();
            g_script.i = g_cell_ind_arr[x];
            g_cell_sprite = g_cells_arr[x].GetComponent<Image>();
            grenade_sprite = grenades_arr[g_script.i].GetComponent<Image>();
            g_cell_sprite.sprite = grenade_sprite.sprite;
        }
    }
    public GameObject weapon_light;
    public GameObject skins_light;
    public GameObject traps_light;
    public GameObject granage_light;
    private RectTransform weapon_trans;
    private RectTransform skins_trans;
    private RectTransform traps_trans;
    private RectTransform granage_trans;
    public GameObject weapon_category;
    public GameObject skins_category;
    public GameObject traps_category;
    public GameObject granage_category;
    public void Light_off()
    {
        for (int i = 0; i < 6; i++)
            light[i].SetActive(false);
        for (int i = 0; i < 9; i++)
            change_weapon.weapons[i].SetActive(false);
    }
    public void Weapon() 
    {
        OFF_ALL();
        UpdateCells();
        cell = weapon_cell_1.GetComponent<RectTransform>();
        cell.anchoredPosition = new Vector2(-420,cell.anchoredPosition.y);cell.localScale = new Vector3(1.3f,1.3f,1f);
        cell = weapon_cell_2.GetComponent<RectTransform>(); cell.localScale = new Vector3(1.3f, 1.3f, 1f);
        cell = weapon_cell_3.GetComponent<RectTransform>(); cell.localScale = new Vector3(1.3f, 1.3f, 1f);
        cell.anchoredPosition = new Vector2(-420, cell.anchoredPosition.y);
        skins_menu.SetActive(false);skins_light.SetActive(false);skins_trans.anchoredPosition = new Vector2(skins_trans.anchoredPosition.x, 281);
        traps_menu.SetActive(false); traps_light.SetActive(false); traps_trans.anchoredPosition = new Vector2(traps_trans.anchoredPosition.x, 281);
        granage_menu.SetActive(false);granage_light.SetActive(false); granage_trans.anchoredPosition = new Vector2(granage_trans.anchoredPosition.x, 281);
        weapons_menu.SetActive(true); weapon_light.SetActive(true); weapon_trans.anchoredPosition = new Vector2(weapon_trans.anchoredPosition.x, 289);
    }
    public void Skins() 
    {
        OFF_ALL();
        UpdateCells();
        cell = skins_cell_1.GetComponent<RectTransform>(); cell.localScale = new Vector3(1.3f, 1.3f, 1f);
        cell.anchoredPosition = new Vector2(cell.anchoredPosition.x,60);
        cell = skins_cell_2.GetComponent<RectTransform>(); cell.localScale = new Vector3(1.3f, 1.3f, 1f);
        cell = skins_cell_3.GetComponent<RectTransform>(); cell.localScale = new Vector3(1.3f, 1.3f, 1f);
        cell.anchoredPosition = new Vector2(cell.anchoredPosition.x, 60);
        traps_menu.SetActive(false); traps_light.SetActive(false); traps_trans.anchoredPosition = new Vector2(traps_trans.anchoredPosition.x, 281);
        granage_menu.SetActive(false); granage_light.SetActive(false); granage_trans.anchoredPosition = new Vector2(granage_trans.anchoredPosition.x, 281);
        weapons_menu.SetActive(false); weapon_light.SetActive(false); weapon_trans.anchoredPosition = new Vector2(weapon_trans.anchoredPosition.x, 281);
        skins_menu.SetActive(true); skins_light.SetActive(true); skins_trans.anchoredPosition = new Vector2(skins_trans.anchoredPosition.x, 289);
    }
    public void Traps()
    {
        OFF_ALL();
        UpdateCells();
        cell = traps_cell_1.GetComponent<RectTransform>(); cell.localScale = new Vector3(1.3f, 1.3f, 1f);
        cell.anchoredPosition = new Vector2(cell.anchoredPosition.x, 29);
        cell = traps_cell_2.GetComponent<RectTransform>(); cell.localScale = new Vector3(1.3f, 1.3f, 1f);
        cell = traps_cell_3.GetComponent<RectTransform>(); cell.localScale = new Vector3(1.3f, 1.3f, 1f);
        cell.anchoredPosition = new Vector2(cell.anchoredPosition.x, 29);
        skins_menu.SetActive(false); skins_light.SetActive(false); skins_trans.anchoredPosition = new Vector2(skins_trans.anchoredPosition.x, 281);
        granage_menu.SetActive(false); granage_light.SetActive(false); granage_trans.anchoredPosition = new Vector2(granage_trans.anchoredPosition.x, 281);
        weapons_menu.SetActive(false); weapon_light.SetActive(false); weapon_trans.anchoredPosition = new Vector2(weapon_trans.anchoredPosition.x, 281);
        traps_menu.SetActive(true); traps_light.SetActive(true); traps_trans.anchoredPosition = new Vector2(traps_trans.anchoredPosition.x, 289);
    }
    public void Granage()
    {
        OFF_ALL();
        UpdateCells();
        i = 0;
        cell = granage_cell_1.GetComponent<RectTransform>(); cell.localScale = new Vector3(1.3f, 1.3f, 1f);
        cell.anchoredPosition = new Vector2(-454,cell.anchoredPosition.y);
        cell = granage_cell_2.GetComponent<RectTransform>(); cell.localScale = new Vector3(1.3f, 1.3f, 1f);
        cell = granage_cell_3.GetComponent<RectTransform>(); cell.localScale = new Vector3(1.3f, 1.3f, 1f);
        cell.anchoredPosition = new Vector2(-454, cell.anchoredPosition.y);
        skins_menu.SetActive(false); skins_light.SetActive(false); skins_trans.anchoredPosition = new Vector2(skins_trans.anchoredPosition.x, 281);
        traps_menu.SetActive(false);traps_light.SetActive(false); traps_trans.anchoredPosition = new Vector2(traps_trans.anchoredPosition.x, 281);
        weapons_menu.SetActive(false);weapon_light.SetActive(false); weapon_trans.anchoredPosition = new Vector2(weapon_trans.anchoredPosition.x, 281);
        granage_menu.SetActive(true); granage_light.SetActive(true); granage_trans.anchoredPosition = new Vector2(granage_trans.anchoredPosition.x, 289);
    }
    public GameObject weapon_cell_1;
    public GameObject weapon_cell_2;
    public GameObject weapon_cell_3;
    public GameObject skins_cell_1;
    public GameObject skins_cell_2;
    public GameObject skins_cell_3;
    public GameObject traps_cell_1;
    public GameObject traps_cell_2;
    public GameObject traps_cell_3;
    public GameObject granage_cell_1;
    public GameObject granage_cell_2;
    public GameObject granage_cell_3;
    private GameObject[] cells;
    private float[,] cells_pos;
    private RectTransform cell;
    private void UpdateCells() 
    { 
        for(int k = 0; k < 12; k++) {
            cell = cells[k].GetComponent<RectTransform>();
            cell.anchoredPosition=new Vector2(cells_pos[k,0],cells_pos[k, 1]);
            cell.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    private void OFF_ALL()
    {
        for (int x = 0; x < weapons_arr.Length; x++)
            weapons_arr[x].SetActive(false);
        for (int x = 0; x < grenades_arr.Length; x++)
            grenades_arr[x].SetActive(false);
        stop = true;
    }
}
