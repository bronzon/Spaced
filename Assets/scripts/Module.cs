using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public abstract class Module : MonoBehaviour {
	public string moduleName;
	public int mass;

    public List<AttachmentPoint> GetAttachmentPoints() {
        return transform.GetComponentsInChildren<AttachmentPoint>().ToList();
    }

    public AttachmentPoint FindAttachmentPoint(AttachmentFacingDirection direction) {
        foreach (AttachmentPoint ap in GetAttachmentPoints()) {
            if (ap.attachmentFacingDirection == direction) {
                return ap;
            }
        }
        return null;
    }

	public abstract void Launch ();
			
	public abstract string GetDescription ();

}
