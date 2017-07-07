// Type: iTextSharp.text.Paragraph
// Assembly: itextsharp, Version=5.5.10.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// Assembly location: C:\Users\Baran.Topal\Downloads\itextsharp-all-5.5.10\itextsharp-dll-core\itextsharp.dll

using iTextSharp.text.api;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.interfaces;
using System;
using System.Collections.Generic;

namespace iTextSharp.text
{
    /// <summary>
    /// A Paragraph is a series of Chunks and/or Phrases.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// A Paragraph has the same qualities of a Phrase, but also
    ///             some additional layout-parameters:
    ///             <UL><LI/>the indentation
    ///             <LI/>the alignment of the text
    ///             </UL>
    /// </remarks>
    /// 
    /// <example>
    /// 
    /// <code>
    /// <strong>Paragraph p = new Paragraph("This is a paragraph",
    ///                            FontFactory.GetFont(FontFactory.HELVETICA, 18, Font.BOLDITALIC, new BaseColor(0, 0, 255)));</strong>
    /// </code>
    /// 
    /// </example>
    /// <seealso cref="T:iTextSharp.text.Element"/><seealso cref="T:iTextSharp.text.Phrase"/><seealso cref="T:iTextSharp.text.ListItem"/>
    public class Paragraph : Phrase, IIndentable, ISpaceable, IAccessibleElement
    {
        /// <summary>
        /// The alignment of the text.
        /// </summary>
        protected int alignment;

        /// <summary>
        /// The indentation of this paragraph on the left side.
        /// </summary>
        protected float indentationLeft;

        /// <summary>
        /// The indentation of this paragraph on the right side.
        /// </summary>
        protected float indentationRight;

        /// The spacing before the paragraph.
        protected float spacingBefore;

        /// The spacing after the paragraph.
        protected float spacingAfter;

        /// <summary>
        /// Does the paragraph has to be kept together on 1 page.
        /// </summary>
        protected bool keeptogether;

        protected float paddingTop;
        protected PdfName role;
        protected Dictionary<PdfName, PdfObject> accessibleAttributes;

        /// <summary>
        /// Constructs a Paragraph.
        /// 
        /// </summary>
        public Paragraph();

        /// <summary>
        /// Constructs a Paragraph with a certain leading.
        /// 
        /// </summary>
        /// <param name="leading">the leading</param>
        public Paragraph(float leading);

        /// <summary>
        /// Constructs a Paragraph with a certain Chunk.
        /// 
        /// </summary>
        /// <param name="chunk">a Chunk</param>
        public Paragraph(Chunk chunk);

        /// <summary>
        /// Constructs a Paragraph with a certain Chunk
        ///             and a certain leading.
        /// 
        /// </summary>
        /// <param name="leading">the leading</param><param name="chunk">a Chunk</param>
        public Paragraph(float leading, Chunk chunk);

        /// <summary>
        /// Constructs a Paragraph with a certain string.
        /// 
        /// </summary>
        /// <param name="str">a string</param>
        public Paragraph(string str);

        /// <summary>
        /// Constructs a Paragraph with a certain string
        ///             and a certain Font.
        /// 
        /// </summary>
        /// <param name="str">a string</param><param name="font">a Font</param>
        public Paragraph(string str, iTextSharp.text.Font font);

        /// <summary>
        /// Constructs a Paragraph with a certain string
        ///             and a certain leading.
        /// 
        /// </summary>
        /// <param name="leading">the leading</param><param name="str">a string</param>
        public Paragraph(float leading, string str);

        /// <summary>
        /// Constructs a Paragraph with a certain leading, string
        ///             and Font.
        /// 
        /// </summary>
        /// <param name="leading">the leading</param><param name="str">a string</param><param name="font">a Font</param>
        public Paragraph(float leading, string str, iTextSharp.text.Font font);

        /// <summary>
        /// Constructs a Paragraph with a certain Phrase.
        /// 
        /// </summary>
        /// <param name="phrase">a Phrase</param>
        public Paragraph(Phrase phrase);

        /// Creates a shallow clone of the Paragraph.
        ///             @return
        public virtual Paragraph CloneShallow(bool spacingBefore);

        protected void PopulateProperties(Paragraph copy, bool spacingBefore);

        /// Creates a shallow clone of the Paragraph.
        ///             @return
        [Obsolete]
        public virtual Paragraph cloneShallow(bool spacingBefore);

        /// Breaks this Paragraph up in different parts, separating paragraphs, lists and tables from each other.
        ///             @return
        public virtual IList<IElement> BreakUp();

        /// Breaks this Paragraph up in different parts, separating paragraphs, lists and tables from each other.
        ///             @return
        [Obsolete]
        public IList<IElement> breakUp();

        /// <summary>
        /// Adds an Object to the Paragraph.
        /// 
        /// </summary>
        /// <param name="o">the object to add</param>
        /// <returns>
        /// a bool
        /// </returns>
        public override bool Add(IElement o);

        public virtual PdfObject GetAccessibleAttribute(PdfName key);
        public virtual void SetAccessibleAttribute(PdfName key, PdfObject value);
        public virtual Dictionary<PdfName, PdfObject> GetAccessibleAttributes();

        /// <summary>
        /// Gets the type of the text element.
        /// 
        /// </summary>
        /// 
        /// <value>
        /// a type
        /// </value>
        public override int Type { get; }

        /// <summary>
        /// Get/set the alignment of this paragraph.
        /// 
        /// </summary>
        /// 
        /// <value>
        /// a integer
        /// </value>
        public virtual int Alignment { get; set; }

        /// <summary>
        /// Get/set the indentation of this paragraph on the left side.
        /// 
        /// </summary>
        /// 
        /// <value>
        /// a float
        /// </value>
        public virtual float IndentationLeft { get; set; }

        /// <summary>
        /// Get/set the indentation of this paragraph on the right side.
        /// 
        /// </summary>
        /// 
        /// <value>
        /// a float
        /// </value>
        public virtual float IndentationRight { get; set; }

        public virtual float SpacingBefore { get; set; }
        public virtual float SpacingAfter { get; set; }

        /// <summary>
        /// Set/get if this paragraph has to be kept together on one page.
        /// 
        /// </summary>
        /// 
        /// <value>
        /// a bool
        /// </value>
        public virtual bool KeepTogether { get; set; }

        public virtual float FirstLineIndent { get; set; }
        public virtual float ExtraParagraphSpace { get; set; }
        public virtual PdfName Role { get; set; }
        public virtual AccessibleElementId ID { get; set; }
        public virtual bool IsInline { get; }
        public virtual float PaddingTop { get; set; }
    }
}
